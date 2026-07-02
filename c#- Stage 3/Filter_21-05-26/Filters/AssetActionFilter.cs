using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter_21_05_26.Filters
{
    public class AssetActionFilter: IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action executed.");
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action executing.");
        }
    }
}
