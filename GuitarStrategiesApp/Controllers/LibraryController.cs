using Microsoft.AspNetCore.Mvc;

namespace GuitarStrategiesApp.Controllers;

public class LibraryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}