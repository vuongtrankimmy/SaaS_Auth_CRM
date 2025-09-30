using Microsoft.Extensions.Logging;

namespace Infrastructures.Middleware.ExceptionMiddleware
{
    public class ErrorDetail
    {
        public int? statusCode { get; set; }
        public string message { get; set; }
    }

    public class ErrorHandlingService
    {
        private readonly ILogger<ErrorHandlingService> _logger;

        public ErrorHandlingService(ILogger<ErrorHandlingService> logger)
        {
            _logger = logger;
        }

        public void HandleException(Exception ex)
        {
            // Ghi nhật ký lỗi hoặc thực hiện các hành động khác
            _logger.LogError(ex, "An unhandled exception has occurred.");
        }
    }
}
