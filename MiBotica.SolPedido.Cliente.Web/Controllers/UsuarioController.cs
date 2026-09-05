using Microsoft.AspNetCore.Mvc;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;

namespace MiBotica.SolPedido.Cliente.Web.Controllers;

public class UsuarioController : Controller
{
    // GET
    public IActionResult Index()
    {
        // idk
        List<Usuario> usuario = new List<Usuario>();
        usuario = new UsuarioLN().ListaUsuarios();
        
        return View(usuario);
    }
}