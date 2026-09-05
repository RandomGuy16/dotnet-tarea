using System.Data;
using Microsoft.Data.SqlClient;
using MiBotica.SolPedido.Entidades.Core;


namespace  MiBotica.SolPedido.AccesoDatos.Core;

public class UsuarioDA : BaseDA
{

    // metodo para listar usuarios de la base de datos
    // retorna lista de usuarios
    public List<Usuario> ListaUsuarios()
    {
        // se declara el contenedor y traveler
        List<Usuario> listaEntidad = new List<Usuario>();
        Usuario entidad = null;

        using (SqlConnection conexion = ObtenerConexion())
        {
            using (SqlCommand comando = new SqlCommand("paUsuarioLista", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    entidad = LlenarEntidad(reader);
                    listaEntidad.Add(entidad);
                }
            }
            conexion.Close();
        }
        return listaEntidad;
    }
    
    public Usuario LlenarEntidad(IDataReader reader)
    {
        Usuario usuario = new Usuario();
        reader.GetSchemaTable().DefaultView.RowFilter ="ColumnName='IdUsuario'";

        if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
        {
            if (!Convert.IsDBNull(reader["IdUsuario"])) usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
        }
        reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Clave'";
        
        if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
        {
            if (!Convert.IsDBNull(reader["Clave"]))
                usuario.Clave = (byte[])reader["Clave"];
        }
        reader.GetSchemaTable().DefaultView.RowFilter ="ColumnName='CodUsuario'";

        if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
        {
            if (!Convert.IsDBNull(reader["CodUsuario"])) usuario.CodUsuario = Convert.ToString(reader["CodUsuario"]);
        }
        
        reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombres'";
        if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
        {
            if (!Convert.IsDBNull(reader["Nombres"]))usuario.Nombres = Convert.ToString(reader["Nombres"]);
        }
        return usuario;
        
    }
}

