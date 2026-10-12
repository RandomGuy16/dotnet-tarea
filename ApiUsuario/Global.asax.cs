using System.Web.Http;
using System.Collections.Generic;
using MiBotica.SolPedido.Entidades.Core;

namespace ApiUsuario
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Variables.ListaClientes = new List<Cliente>
            {
                new Cliente { Codigo = 1, NombreCompleto = "Ricaardo Gutarra", Zona = "Callao" },
                new Cliente { Codigo = 2, NombreCompleto = "David Espinoza", Zona = "Jesus Maria" },
                new Cliente { Codigo = 3, NombreCompleto = "Victor Hidalgo", Zona = "San Martin" },
                new Cliente { Codigo = 4, NombreCompleto = "Gladys Gutierrez", Zona = "Pueblo Libre" },
                new Cliente { Codigo = 5, NombreCompleto = "Mariza Zegarra", Zona = "San Juan" }
            };
        }
    }
}
