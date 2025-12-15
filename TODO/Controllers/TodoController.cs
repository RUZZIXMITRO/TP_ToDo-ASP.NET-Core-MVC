using Microsoft.AspNetCore.Mvc;

public class TodoController : Controller
{
    private List<TodoVM> GetTodos()
    {
        var list = HttpContext.Session.GetObject<List<TodoVM>>("TODOS");
        if (list == null)
        {
            list = new List<TodoVM>();
            HttpContext.Session.SetObject("TODOS", list);
        }
        return list;
    }

    private void SaveTodos(List<TodoVM> list)
    {
        HttpContext.Session.SetObject("TODOS", list);
    }

    public IActionResult Index()
    {
        return View(GetTodos());
    }


    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(TodoVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var list = GetTodos();
        list.Add(model);
        SaveTodos(list);

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var list = GetTodos();
        list.RemoveAt(id);
        SaveTodos(list);

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        return View(GetTodos()[id]);
    }

    [HttpPost]
    public IActionResult Edit(int id, TodoVM model)
    {
        var list = GetTodos();
        list[id] = model;
        SaveTodos(list);

        return RedirectToAction("Index");
    }
}
