using Microsoft.AspNetCore.Mvc;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
using MiBotica.SolPedido.Utiles.Helpers;

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

    // GET
    public IActionResult Create()
    {
        Usuario usuario = new Usuario();
        return View(usuario);
    }
    // POST: Usuario/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Usuario usuario)
    {
        try
        {
            usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.        
                ClaveTexto);
            new UsuarioLN().InsertarUsuario(usuario);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(usuario);
        }
    }
}