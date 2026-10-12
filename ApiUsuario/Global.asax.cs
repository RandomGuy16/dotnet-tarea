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

            Variables.ListaClientes = new List<Clientes>
            {
                new Clientes { Codigo = 1, NombreCompleto = "Ricaardo Gutarra", Zona = "Callao" },
                new Clientes { Codigo = 2, NombreCompleto = "David Espinoza", Zona = "Jesus Maria" },
                new Clientes { Codigo = 3, NombreCompleto = "Victor Hidalgo", Zona = "San Martin" },
                new Clientes { Codigo = 4, NombreCompleto = "Gladys Gutierrez", Zona = "Pueblo Libre" },
                new Clientes { Codigo = 5, NombreCompleto = "Mariza Zegarra", Zona = "San Juan" }
            };
        }
    }
}
