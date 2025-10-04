using Entities.Common.AuthToken;
using Entities.Common.BaseResponse;
using Helpers.Helper.Convert;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Repositories.Repository
{
    public class QueryRepository: IQueryRepository
    {
        protected readonly RestClient _client;
        protected readonly JsonService _jsonService;

        public QueryRepository(IConfiguration config, JsonService jsonService)
        {
            ArgumentNullException.ThrowIfNull(config, nameof(config));
            ArgumentNullException.ThrowIfNull(jsonService, nameof(jsonService));

            var baseURL = config["DomainSetting:endpoint_api"]
                ?? throw new InvalidOperationException("Endpoint configuration is missing");

            _client = new RestClient(new RestClientOptions(baseURL));
            _jsonService = jsonService;
        }

        protected async Task<T> SendAsync<T>(RestRequest request, Func<RestRequest, Task<RestResponse>> executor)
        {
            var accessToken = AuthToken.AuthTokenProperty?.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                request.AddHeader("Authorization", $"Bearer {accessToken}");
            }

            var response = await executor(request);
            if (response == null)
                throw new HttpRequestException("Response is null from API");

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
                    errorMessage = model.error ?? "Unknown API error";
                }
                catch
                {
                    errorMessage = $"API Error: {response.StatusCode} - {content}";
                }

                throw new HttpRequestException(errorMessage, null, response.StatusCode);
            }
        }

        public async Task<T> GetAsync<T>(string endpoint)
            => await SendAsync<T>(new RestRequest(endpoint, Method.Get), r => _client.ExecuteGetAsync(r));

        public async Task<T> PostAsync<T>(object data, string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Post);
            if (data != null) request.AddBody(data);
            return await SendAsync<T>(request, r => _client.ExecutePostAsync(r));
        }

        public async Task<T> PutAsync<T>(object data, string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Put);
            if (data != null) request.AddBody(data);
            return await SendAsync<T>(request, r => _client.ExecutePutAsync(r));
        }

        public async Task<T> DeleteAsync<T>(string endpoint)
            => await SendAsync<T>(new RestRequest(endpoint, Method.Delete), r => _client.ExecuteDeleteAsync(r));
    }
}
