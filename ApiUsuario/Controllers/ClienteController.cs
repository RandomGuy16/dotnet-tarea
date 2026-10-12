using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MiBotica.SolPedido.Entidades.Core;

namespace ApiUsuario.Controllers
{
    public class ClienteController : ApiController
    {
        public IEnumerable<Cliente> Get()
        {
            return Variables.ListaClientes;
        }

        public IHttpActionResult Get(int id)
        {
            Cliente cliente = Variables.ListaClientes.FirstOrDefault(item => item.Codigo == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        public IHttpActionResult Post([FromBody] Cliente value)
        {
            if (value == null)
            {
                return BadRequest("El cliente es requerido.");
            }

            if (Variables.ListaClientes.Any(item => item.Codigo == value.Codigo))
            {
                return Conflict();
            }

            Variables.ListaClientes.Add(value);
            return CreatedAtRoute("DefaultApi", new { id = value.Codigo }, value);
        }

        public IHttpActionResult Put(int id, [FromBody] Cliente value)
        {
            if (value == null)
            {
                return BadRequest("El cliente es requerido.");
            }

            Cliente cliente = Variables.ListaClientes.FirstOrDefault(item => item.Codigo == id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.NombreCompleto = value.NombreCompleto;
            cliente.Zona = value.Zona;
            return Ok(cliente);
        }

        public IHttpActionResult Delete(int id)
        {
            Cliente cliente = Variables.ListaClientes.FirstOrDefault(item => item.Codigo == id);
            if (cliente == null)
            {
                return NotFound();
            }

            Variables.ListaClientes.Remove(cliente);
            return Ok(cliente);
        }
    }
}
