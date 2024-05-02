using System.Diagnostics;
using FA.LibraryManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA.LibraryManagement.Web.Controllers;

/// <summary>

/// The home controller class

/// </summary>

/// <seealso cref="Controller"/>

public class HomeController : Controller
{
    /// <summary>
    /// The logger
    /// </summary>
    private readonly ILogger<HomeController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="HomeController"/> class
    /// </summary>
    /// <param name="logger">The logger</param>
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Logins this instance
    /// </summary>
    /// <returns>The action result</returns>
    [HttpGet("")]
    public IActionResult Login()
    {
        return View();
    }

    /// <summary>
    /// Registers this instance
    /// </summary>
    /// <returns>The action result</returns>
    [HttpGet("Register")]
    public IActionResult Register()
    {
        return View();
    }

    /// <summary>
    /// Logouts this instance
    /// </summary>
    /// <returns>The action result</returns>
    [HttpGet("/Logout")]
    public IActionResult Logout()
    {
        return RedirectToAction("Login");
    }

    /// <summary>
    /// Forgots the password
    /// </summary>
    /// <returns>The action result</returns>
    [HttpGet("/ForgotPassword")]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    /// <summary>
    /// Errors this instance
    /// </summary>
    /// <returns>The action result</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}