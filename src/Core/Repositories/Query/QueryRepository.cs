using Entities.Common.AuthToken;
using Entities.Common.BaseResponse;
using Helpers.Helper.Convert;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Polly.Timeout;
using Repositories.Repository;
using RestSharp;

public class QueryRepository : IQueryRepository
{
    protected readonly RestClient _client;
    protected readonly JsonService _jsonService;
    private readonly ILogger<QueryRepository> _logger;

    // Polly policies
    private readonly AsyncRetryPolicy<RestResponse> _retryPolicy;
    private readonly AsyncTimeoutPolicy<RestResponse> _timeoutPolicy;
    private readonly AsyncCircuitBreakerPolicy<RestResponse> _circuitBreakerPolicy;

    public QueryRepository(IConfiguration config, JsonService jsonService, ILogger<QueryRepository> logger)
    {
        ArgumentNullException.ThrowIfNull(config);
        ArgumentNullException.ThrowIfNull(jsonService);
        ArgumentNullException.ThrowIfNull(logger);

        _jsonService = jsonService;
        _logger = logger;

        var baseURL = config["DomainSetting:endpoint_api"]
            ?? throw new InvalidOperationException("Endpoint configuration is missing");

        _client = new RestClient(new RestClientOptions(baseURL));

        // 🔹 Retry Policy: retry tối đa 3 lần với backoff (1s, 2s, 4s)
        _retryPolicy = Policy
            .HandleResult<RestResponse>(r => (int)r.StatusCode >= 500 || r.StatusCode == 0)
            .Or<HttpRequestException>()
            .Or<TaskCanceledException>()
            .WaitAndRetryAsync(
                retryCount: 3,
                sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
                onRetry: (outcome, delay, retryAttempt, context) =>
                {
                    _logger.LogWarning(
                        "[Retry {RetryAttempt}] Delay={Delay}s Reason={Reason}",
                        retryAttempt,
                        delay.TotalSeconds,
                        outcome.Exception?.Message ?? outcome.Result?.StatusDescription ?? "Unknown");
                });

        // 🔹 Timeout Policy: tối đa 10 giây mỗi request
        _timeoutPolicy = Policy.TimeoutAsync<RestResponse>(
            seconds: 10,
            onTimeoutAsync: (context, timespan, task, ex) =>
            {
                _logger.LogError("Request timed out after {Time}s", timespan.TotalSeconds);
                return Task.CompletedTask;
            });

        // 🔹 Circuit Breaker Policy: ngắt 10s nếu 5 lỗi liên tiếp
        _circuitBreakerPolicy = Policy
            .HandleResult<RestResponse>(r => (int)r.StatusCode >= 500)
            .CircuitBreakerAsync(
                handledEventsAllowedBeforeBreaking: 5,
                durationOfBreak: TimeSpan.FromSeconds(10),
                onBreak: (result, ts) =>
                {
                    _logger.LogError("Circuit opened for {Duration}s due to repeated failures", ts.TotalSeconds);
                },
                onReset: () =>
                {
                    _logger.LogInformation("Circuit closed, system back to normal");
                },
                onHalfOpen: () =>
                {
                    _logger.LogWarning("Circuit half-open: testing API health...");
                });
    }

    // -----------------------
    // Core SendAsync
    // -----------------------
    protected async Task<T> SendAsync<T>(
        RestRequest request,
        Func<RestRequest, Task<RestResponse>> executor)
    {
        var accessToken = AuthToken.AuthTokenProperty?.access_token;
        if (!string.IsNullOrEmpty(accessToken))
            request.AddHeader("Authorization", $"Bearer {accessToken}");

        // Wrap 3 policy vào pipeline
        var policyPipeline = _timeoutPolicy
            .WrapAsync(_retryPolicy)
            .WrapAsync(_circuitBreakerPolicy);

        RestResponse response;

        try
        {
            response = await policyPipeline.ExecuteAsync(() => executor(request));
            return default;
        }
        catch (BrokenCircuitException)
        {
            _logger.LogError("Circuit is open — skipping request to {Endpoint}", request.Resource);
            throw new HttpRequestException("Service temporarily unavailable due to repeated failures.");
        }

        //if (response == null)
        //    throw new HttpRequestException("No response received from API");

        var content = response.Content ?? string.Empty;

        if (response.IsSuccessful)
        {
            if (string.IsNullOrWhiteSpace(content))
                return default!;

            return JsonService.DeserializeObject<T>(content);
        }
        else
        {
            string errorMessage;
            try
            {
                var model = JsonService.DeserializeObject<ModelResponse>(content);
                errorMessage = model.error ?? $"API Error ({response.StatusCode})";
            }
            catch
            {
                errorMessage = $"HTTP {response.StatusCode}: {content}";
            }

            _logger.LogError("API Error on {Endpoint}: {Error}", request.Resource, errorMessage);
            throw new HttpRequestException(errorMessage, null, response.StatusCode);
        }
    }

    // -----------------------
    // CRUD Wrappers
    // -----------------------
    public async Task<T> GetAsync<T>(string endpoint)
        => await SendAsync<T>(new RestRequest(endpoint, Method.Get), r => _client.ExecuteGetAsync(r));

    public async Task<T> PostAsync<T>(object data, string endpoint)
    {
        var req = new RestRequest(endpoint, Method.Post);
        if (data != null) req.AddBody(data);
        return await SendAsync<T>(req, r => _client.ExecutePostAsync(r));
    }

    public async Task<T> PutAsync<T>(object data, string endpoint)
    {
        var req = new RestRequest(endpoint, Method.Put);
        if (data != null) req.AddBody(data);
        return await SendAsync<T>(req, r => _client.ExecutePutAsync(r));
    }

    public async Task<T> DeleteAsync<T>(string endpoint)
        => await SendAsync<T>(new RestRequest(endpoint, Method.Delete), r => _client.ExecuteDeleteAsync(r));
}
