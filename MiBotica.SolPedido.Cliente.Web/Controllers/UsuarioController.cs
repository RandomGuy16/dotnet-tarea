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
    
    
    // GET
    public IActionResult Edit(int id)
    {
        if (id <= 0) return NotFound();

        Usuario usuario = new UsuarioLN().ObtenerUsuario(id);
        
        if (usuario == null) return NotFound();
        
        return View(usuario);
    }
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Usuario usuario)
    {
        if (id != usuario.IdUsuario) return NotFound();
        
        try
        {
            if (!string.IsNullOrEmpty(usuario.ClaveTexto))
            {
                usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);
            }

            new UsuarioLN().ActualizarUsuario(usuario);
            // redirigir a la pagina principal
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(usuario);
        }
    }
    
    // GET
    public IActionResult Delete(int id)
    {
        if (id <= 0) return NotFound();

        Usuario usuario = new UsuarioLN().ObtenerUsuario(id);

        if (usuario == null) return NotFound();
        
        return View(usuario);
    }
    
    // post
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        try
        {
            new UsuarioLN().EliminarUsuario(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}