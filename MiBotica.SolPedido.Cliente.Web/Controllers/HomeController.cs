using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiBotica.SolPedido.Cliente.Web.Models;

namespace MiBotica.SolPedido.Cliente.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // Equivalente a <error statusCode="500" redirect="Home/Error500"/>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    public IActionResult Error500()
    {
        return View();
    }

    // Equivalente a <error statusCode="404" redirect="Home/PaginaNoEncontrada"/>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    public IActionResult PaginaNoEncontrada()
    {
        return View();
    }
}
