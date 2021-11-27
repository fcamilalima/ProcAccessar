using Microsoft.AspNetCore.Mvc;
using ProcAccessar.Models;
using System.Diagnostics;


namespace ProcAccessar.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}