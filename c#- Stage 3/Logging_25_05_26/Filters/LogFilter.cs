using Microsoft.AspNetCore.Mvc.Filters;

namespace Logging_25_05_26.Filters
{
    public class LogFilter : IActionFilter
    {

        ILogger<LogFilter> _logger;

        public LogFilter(ILogger<LogFilter> logger)
        {

            _logger = logger;

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

            _logger.LogInformation("Action executed at {Time} Name: {ActionName}", DateTime.UtcNow, context.ActionDescriptor.DisplayName);

        }


        public void OnActionExecuting(ActionExecutingContext context)
        {

            _logger.LogInformation("Action executing at {Time} Name: {ActionName}", DateTime.UtcNow, context.ActionDescriptor.DisplayName);

        }

    }
}
