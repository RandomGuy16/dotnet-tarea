using System.Web.Mvc;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
using MiBotica.SolPedido.Utiles.Helpers;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            return View(new UsuarioLN().ListaUsuarios());
        }

        public ActionResult Create()
        {
            return View(new Usuario());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);
                new UsuarioLN().InsertarUsuario(usuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(usuario);
            }
        }

        public ActionResult Edit(int id)
        {
            Usuario usuario = new UsuarioLN().ObtenerUsuario(id);
            return usuario == null ? (ActionResult)HttpNotFound() : View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(usuario.ClaveTexto))
                {
                    usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);
                }

                new UsuarioLN().ActualizarUsuario(usuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(usuario);
            }
        }

        public ActionResult Delete(int id)
        {
            Usuario usuario = new UsuarioLN().ObtenerUsuario(id);
            return usuario == null ? (ActionResult)HttpNotFound() : View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new UsuarioLN().EliminarUsuario(id);
            return RedirectToAction("Index");
        }
    }
}
