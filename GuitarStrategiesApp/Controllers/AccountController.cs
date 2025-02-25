using GuitarStrategiesApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GuitarStrategiesApp.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (model.Email == "test@example.com" && model.Password == "password")
        {
            return RedirectToAction("Index", "Home"); // Redirect on successful login
        }

        ViewBag.Error = "Invalid email or password.";
        return View(model);
    }
}