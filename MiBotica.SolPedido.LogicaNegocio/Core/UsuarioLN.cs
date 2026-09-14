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

    public Usuario ObtenerUsuario(int id)
    {
        try
        {
            return new UsuarioDA().ObtenerUsuario(id);
        }
        catch (Exception ex)
        {
            Log.Error(ex);
            throw;
        }
    }

    public bool ActualizarUsuario(Usuario usuario)
    {
        try
        {
            return new UsuarioDA().ActualizarUsuario(usuario);
        }
        catch (Exception ex)
        {
            Log.Error(ex);
            throw;
        }
    }

    public bool EliminarUsuario(int id)
    {
        try
        {
            return new UsuarioDA().EliminarUsuario(id);
        }
        catch (Exception ex)
        {
            Log.Error(ex);
            throw;
        }
    }
}

