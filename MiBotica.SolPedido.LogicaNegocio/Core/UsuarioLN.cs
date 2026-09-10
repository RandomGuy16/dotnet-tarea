using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Core;

namespace MiBotica.SolPedido.LogicaNegocio.Core;

public class UsuarioLN : BaseLN
{

    // funcion retornadora de lista usuarios
    public List<Usuario> ListaUsuarios()
    {
        try
        {
            return new UsuarioDA().ListaUsuarios();
        }
        catch (Exception ex)
        {
            Log.Error(ex);
            throw;
        }
    }
    
    public bool InsertarUsuario(Usuario usuario)                                 
    {
        try
        {
            return new UsuarioDA().InsertarUsuario(usuario);
        }
        catch (Exception ex)
        {
            Log.Error(ex);
            throw;
        }                                                                        
    }
}

