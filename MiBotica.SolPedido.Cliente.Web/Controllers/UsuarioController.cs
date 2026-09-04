using Microsoft.AspNetCore.Mvc;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;

namespace MiBotica.SolPedido.Cliente.Web.Controllers;

public class UsuarioController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}