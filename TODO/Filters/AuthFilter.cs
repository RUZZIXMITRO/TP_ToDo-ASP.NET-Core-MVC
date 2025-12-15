using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class AuthFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var controller = context.RouteData.Values["controller"]?.ToString();
        var action = context.RouteData.Values["action"]?.ToString();

        // Autoriser le login
        if (controller == "User" && action == "LoginForm")
            return;

        var user = context.HttpContext.Session.GetString("user");

        if (string.IsNullOrEmpty(user))
        {
            context.Result = new RedirectToActionResult("LoginForm", "User", null);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}

