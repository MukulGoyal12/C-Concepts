using Microsoft.AspNetCore.Mvc.Filters;

namespace Logging_25_05_26.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {

        ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)

        {

            _logger = logger;

        }

        public void OnException(ExceptionContext context)

        {

            //logging the exception details using Serilog to log file            _logger.LogError(context.Exception, "An unhandled exception occurred at {Time}", DateTime.UtcNow);

            _logger.LogError("Exception Message: {Message}", context.Exception.Message);

            context.ExceptionHandled = true; // Marking the exception as handled to prevent it from propagating further        

        }

    }  
}
