using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    public IActionResult LoginForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult LoginForm(UserVM model)
    {
        if (model.Login == "admin" && model.Password == "1234")
        {
            HttpContext.Session.SetString("user", model.Login);
            return RedirectToAction("Index", "Todo");
        }

        ViewBag.Error = "Login ou mot de passe incorrect";
        return View(model);
    }


    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("LoginForm");
    }

}
