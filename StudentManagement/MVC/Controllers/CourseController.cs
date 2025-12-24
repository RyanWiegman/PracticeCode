using Microsoft.AspNetCore.Mvc;

public class CourseController : Controller
{
    public CourseController() { }

    public IActionResult Index()
    {
        return View();
    }
}