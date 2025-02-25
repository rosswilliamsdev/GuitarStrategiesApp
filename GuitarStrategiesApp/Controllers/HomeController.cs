using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GuitarStrategiesApp.Models;
using GuitarStrategiesApp.ViewModels;

namespace GuitarStrategiesApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        User testUser = new User()
        {
            Id = 1,
            Name = "Ross Williams",
            Email = "test@example.com"
        };
        
        return View(testUser);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}