using Microsoft.Data.SqlClient;

namespace Jugueteria.Data
{
    public class Conexion
    {
        
        private readonly string _cadenaConexion = "Server=localhost; Database=JUGUETERIA; Integrated Security=True; TrustServerCertificate=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }
    }
}
