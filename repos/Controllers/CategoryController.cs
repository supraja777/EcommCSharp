using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using repos.Models;

namespace repos.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}
