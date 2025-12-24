using Microsoft.AspNetCore.Mvc;

public class EnrollmentController : Controller
{
    public EnrollmentController() { }

    public IActionResult Index()
    {
        return View();
    }
}