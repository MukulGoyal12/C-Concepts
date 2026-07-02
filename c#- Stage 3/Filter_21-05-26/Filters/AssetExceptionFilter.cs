using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter_21_05_26.Filters
{
    public class AssetExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();
        }

    }
}
