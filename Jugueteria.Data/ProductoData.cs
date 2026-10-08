using System.Data;
using Microsoft.Data.SqlClient;
using Jugueteria.Entity;

namespace Jugueteria.Data
{
    public class ProductoData
    {
        private readonly Conexion _conexion = new Conexion();

     
        public List<Producto> ObtenerTodos()
        {
            var lista = new List<Producto>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerProductos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Producto
                            {
                                ProductoId = Convert.ToInt32(reader["ProductoId"]),
                                Nombre = reader["Nombre"].ToString()!,
                                CategoriaId = Convert.ToInt32(reader["CategoriaId"]),
                                PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                                Existencia = Convert.ToInt32(reader["Existencia"]),
                                MarcaId = Convert.ToInt32(reader["MarcaId"]),
                                EdadId = Convert.ToInt32(reader["EdadId"]),
                                MaterialId = Convert.ToInt32(reader["MaterialId"]),
                                Estado = reader["Estado"].ToString()!
                            });
                        }
                    }
                }
            }
            return lista;
        }

       
        public bool Insertar(Producto producto)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarProducto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@CategoriaId", producto.CategoriaId);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", producto.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@Existencia", producto.Existencia);
                    cmd.Parameters.AddWithValue("@MarcaId", producto.MarcaId);
                    cmd.Parameters.AddWithValue("@EdadId", producto.EdadId);
                    cmd.Parameters.AddWithValue("@MaterialId", producto.MaterialId);
                    cmd.Parameters.AddWithValue("@Estado", producto.Estado);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}