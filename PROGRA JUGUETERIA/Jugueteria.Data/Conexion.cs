using Microsoft.Data.SqlClient;

namespace Jugueteria.Data
{
    public class Conexion
    {
        // Cambiamos a Autenticación de Windows integrada (Trusted_Connection)
        private readonly string cadenaConexion = "Server=.\\SQLEXPRESS;Database=JUGUETERIA;Trusted_Connection=True;TrustServerCertificate=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}