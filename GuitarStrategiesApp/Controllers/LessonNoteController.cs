using Microsoft.AspNetCore.Mvc;

namespace GuitarStrategiesApp.Controllers;

public class LessonNotesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}