using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Core;

namespace MiBotica.SolPedido.LogicaNegocio.Core;

public class UsuarioLN
{

    // funcion retornadora de lista usuarios
    public List<Usuario> ListaUsuarios()
    {
        try
        {
            return new UsuarioDA().ListaUsuarios();
        }
        catch (Exception)
        {
            throw;
        }
    }
}

