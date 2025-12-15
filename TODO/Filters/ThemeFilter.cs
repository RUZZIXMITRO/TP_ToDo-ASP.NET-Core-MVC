using Microsoft.AspNetCore.Mvc.Filters;

public class ThemeFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var theme = context.HttpContext.Request.Cookies["theme"];
        context.HttpContext.Items["theme"] = theme ?? "light";
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
