using System.Diagnostics;
using Efcore_demo.Data;
using Efcore_demo.Entities;
using Microsoft.AspNetCore.Mvc;
using Efcore_demo.Models;

namespace Efcore_demo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;


   

    public IActionResult Index()
    {
        
        return View();
    }

    public IActionResult Edit(long id)
    {
        return View();
    }

    
    
    
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}