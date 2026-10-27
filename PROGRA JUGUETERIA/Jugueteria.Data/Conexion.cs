using Microsoft.Data.SqlClient;

namespace Jugueteria.Data
{
    public class Conexion
    {
        
        private readonly string cadenaConexion = "Server=10.10.40.75;Database=JUGUETERIA;User Id=sa;Password=callejasserver2026;TrustServerCertificate=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}