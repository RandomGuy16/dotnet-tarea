using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MiBotica.SolPedido.Entidades;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.Utiles.Helpers;

namespace MiBotica.SolPedido.Cliente.Web.Controllers;

public class LoginController : Controller
{
    // GET: Login
    public IActionResult Index()
    {
        Usuario u = new Usuario();
        return View(u);
    }

    // POST: Login
    [HttpPost]
    public IActionResult Index(Usuario usuario)
    {
        // Paso 54: La lógica completa de validación contra base de datos se implementa en pasos posteriores.
        return View(usuario);
    }

    // GET: Login/CerrarSesion
    public async Task<IActionResult> CerrarSesion()
    {
        VariablesWeb.gUsuario = null;
        VariablesWeb.gOpciones = new List<Opcion>();
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction(nameof(Index));
    }
}
