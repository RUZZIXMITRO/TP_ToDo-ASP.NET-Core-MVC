using Microsoft.AspNetCore.Mvc;

public class ThemeController : Controller
{
    public IActionResult Switch()
    {
        string theme = Request.Cookies["theme"] == "dark" ? "light" : "dark";

        Response.Cookies.Append("theme", theme, new CookieOptions
        {
            Expires = DateTime.Now.AddYears(1)
        });

        return Redirect(Request.Headers["Referer"].ToString());
    }
}
