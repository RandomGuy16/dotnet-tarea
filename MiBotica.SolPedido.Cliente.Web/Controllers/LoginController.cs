using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MiBotica.SolPedido.Entidades;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
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
    public async Task<IActionResult> Index(Usuario usuario)
    {
        if (string.IsNullOrEmpty(usuario.CodUsuario) || string.IsNullOrEmpty(usuario.ClaveTexto))
        {
            ModelState.AddModelError(string.Empty, "Debe llenar el usuario o clave");
        }

        if (ModelState.IsValid)
        {
            try
            {
                usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);
                Usuario res = new UsuarioLN().BuscarUsuario(usuario);

                if (res != null && res.IdUsuario > 0)
                {
                    // Reemplazo moderno de FormsAuthentication.SetAuthCookie
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, res.CodUsuario)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    // Llenar datos en variables de entorno / sesión
                    List<Opcion> lista = new OpcionLN().ListaOpciones();
                    ParsearAcciones(lista);
                    VariablesWeb.gOpciones = lista;
                    VariablesWeb.gUsuario = res;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario / Clave no válidos");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }

        return View(usuario);
    }

    // GET: Login/CerrarSesion
    public async Task<IActionResult> CerrarSesion()
    {
        VariablesWeb.gUsuario = null;
        VariablesWeb.gOpciones = new List<Opcion>();

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Home");
    }

    [NonAction]
    private void ParsearAcciones(List<Opcion> lista)
    {
        foreach (Opcion item in lista)
        {
            if (!string.IsNullOrEmpty(item.UrlOpcion))
            {
                var partes = item.UrlOpcion.Split('/');
                int cantidad = partes.Length;

                switch (cantidad)
                {
                    case 3:
                        item.Area = partes[0];
                        item.Controladora = partes[1];
                        item.Accion = partes[2];
                        break;
                    case 2:
                        item.Controladora = partes[0];
                        item.Accion = partes[1];
                        break;
                    case 1:
                        item.Controladora = partes[0];
                        item.Accion = "Index";
                        break;
                }
            }
        }
    }
}