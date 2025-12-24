using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller
{
    public StudentController() { }

    public IActionResult Index()
    {
        return View();
    }
}