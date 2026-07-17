using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemoApi.Filters
{
    // Action filter runs before and after an action method executes.
    public class CustomActionFilter : IActionFilter
    {
        private readonly ILogger<CustomActionFilter> _logger;

        public CustomActionFilter(ILogger<CustomActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.BadRequestObjectResult(context.ModelState);
                return;
            }

            _logger.LogInformation("Action {Action} is executing.", context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Action {Action} executed.", context.ActionDescriptor.DisplayName);
        }
    }
}
