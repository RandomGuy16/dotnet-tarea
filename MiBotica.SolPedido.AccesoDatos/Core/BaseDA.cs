using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MiBotica.SolPedido.AccesoDatos.Core;

public abstract class BaseDA
{
    protected static string ConnectionString { get; set; } =
        "Server=localhost,1433;Database=BDPedido;User Id=sa;Password=mibotica_dbA12345$;TrustServerCertificate=True";

    public static void Initialize(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public static void Initialize(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        // Replicar el patrón del profesor: cnnSql apunta a la clave en ConnectionStrings
        var connectionKey = configuration["AppSettings:cnnSql"] ?? "SQL";
        var connStr = configuration.GetConnectionString(connectionKey)
                      ?? configuration[$"ConnectionStrings:{connectionKey}"];

        if (!string.IsNullOrWhiteSpace(connStr))
        {
            ConnectionString = connStr;
        }
    }

    protected SqlConnection ObtenerConexion() => new SqlConnection(ConnectionString);
}
