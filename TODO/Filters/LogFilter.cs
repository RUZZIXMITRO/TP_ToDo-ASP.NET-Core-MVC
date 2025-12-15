using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

public class LogFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var user = context.HttpContext.Session.GetString("user") ?? "Anonymous";
        var controller = context.RouteData.Values["controller"];
        var action = context.RouteData.Values["action"];

        var log = $"{date} - {user} - {controller} - {action}\n";

        File.AppendAllText("logs/actions.log", log, Encoding.UTF8);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
