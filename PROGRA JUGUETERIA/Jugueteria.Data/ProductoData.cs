using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Jugueteria.Entity;
using Juguetería.Entity.Interfaces;

namespace Jugueteria.Data
{
    public class ProductoData : IProductoData
    {
        private readonly Conexion _conexion = new Conexion();

        // 1. Obtener todos los productos
        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            var lista = new List<Producto>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerProductos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Producto
                            {
                                ProductoId = Convert.ToInt32(reader["Id"]),
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

        // 2. Obtener un producto por su ID
        public async Task<Producto> GetByIdAsync(int id)
        {
            Producto producto = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerProductoPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            producto = new Producto
                            {
                                ProductoId = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString()!,
                                CategoriaId = Convert.ToInt32(reader["CategoriaId"]),
                                PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                                Existencia = Convert.ToInt32(reader["Existencia"]),
                                MarcaId = Convert.ToInt32(reader["MarcaId"]),
                                EdadId = Convert.ToInt32(reader["EdadId"]),
                                MaterialId = Convert.ToInt32(reader["MaterialId"]),
                                Estado = reader["Estado"].ToString()!
                            };
                        }
                    }
                }
            }
            return producto;
        }

        // 3. Agregar un nuevo producto
        public async Task AddAsync(Producto producto)
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

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Actualizar un producto existente
        public async Task UpdateAsync(Producto producto)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ActualizarProducto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", producto.ProductoId);
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@CategoriaId", producto.CategoriaId);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", producto.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@Existencia", producto.Existencia);
                    cmd.Parameters.AddWithValue("@MarcaId", producto.MarcaId);
                    cmd.Parameters.AddWithValue("@EdadId", producto.EdadId);
                    cmd.Parameters.AddWithValue("@MaterialId", producto.MaterialId);
                    cmd.Parameters.AddWithValue("@Estado", producto.Estado);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Eliminar un producto por ID
        public async Task DeleteAsync(int id)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_EliminarProducto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}