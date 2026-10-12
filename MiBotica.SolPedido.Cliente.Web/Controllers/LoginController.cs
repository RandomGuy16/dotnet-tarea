using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using MiBotica.SolPedido.Entidades;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
using MiBotica.SolPedido.Utiles.Helpers;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(new Usuario());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.CodUsuario) ||
                string.IsNullOrWhiteSpace(usuario.ClaveTexto))
            {
                ModelState.AddModelError(string.Empty, "Debe llenar el usuario o clave");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);
                    Usuario resultado = new UsuarioLN().BuscarUsuario(usuario);
                    if (resultado != null && resultado.IdUsuario > 0)
                    {
                        FormsAuthentication.SetAuthCookie(resultado.CodUsuario, true);
                        VariablesWeb.gUsuario = resultado;
                        VariablesWeb.gOpciones = new OpcionLN().ListaOpciones();
                        ParsearAcciones(VariablesWeb.gOpciones);
                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError(string.Empty, "Usuario / Clave no validos");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View(usuario);
        }

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            VariablesWeb.gUsuario = null;
            VariablesWeb.gOpciones = new List<Opcion>();
            return RedirectToAction("Index");
        }

        private static void ParsearAcciones(IEnumerable<Opcion> opciones)
        {
            foreach (Opcion opcion in opciones)
            {
                if (string.IsNullOrWhiteSpace(opcion.UrlOpcion))
                {
                    continue;
                }

                string[] partes = opcion.UrlOpcion.Split('/');
                if (partes.Length == 3)
                {
                    opcion.Area = partes[0];
                    opcion.Controladora = partes[1];
                    opcion.Accion = partes[2];
                }
                else if (partes.Length == 2)
                {
                    opcion.Controladora = partes[0];
                    opcion.Accion = partes[1];
                }
                else if (partes.Length == 1)
                {
                    opcion.Controladora = partes[0];
                    opcion.Accion = "Index";
                }
            }
        }
    }
}
