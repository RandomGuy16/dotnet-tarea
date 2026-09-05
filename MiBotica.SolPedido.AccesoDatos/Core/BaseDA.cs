using Microsoft.Data.SqlClient;

namespace MiBotica.SolPedido.AccesoDatos.Core;

public abstract class BaseDA
{
    protected static string ConnectionString { get; set; } =
        "Server=localhost,1433;Database=BDPedido;User Id=sa;Password=mibotica_dbA12345$;TrustServerCertificate=True";

    public static void Initialize(string connectionString)
    {
        ConnectionString = connectionString;
    }

    protected SqlConnection ObtenerConexion() => new SqlConnection(ConnectionString);
}
