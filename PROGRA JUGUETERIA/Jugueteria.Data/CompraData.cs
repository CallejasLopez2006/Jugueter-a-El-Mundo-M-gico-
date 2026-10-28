using Jugueteria.Entity;
using Juguetería.Entity;
using Juguetería.Entity.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Jugueteria.Data
{
    public class CompraData : ICompraData
    {
        private readonly Conexion _conexion = new Conexion();

        // 1. Obtener todas las compras
        public async Task<IEnumerable<Compra>> GetAllAsync()
        {
            var lista = new List<Compra>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerCompras", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Compra
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FechaCompra = Convert.ToDateTime(reader["FechaCompra"]),
                                Estado = reader["Estado"]?.ToString()!,
                                ProductoId = Convert.ToInt32(reader["ProductoId"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 2. Obtener una compra por ID
        public async Task<Compra> GetByIdAsync(int id)
        {
            Compra compra = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerCompraPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            compra = new Compra
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FechaCompra = Convert.ToDateTime(reader["FechaCompra"]),
                                Estado = reader["Estado"]?.ToString()!,
                                ProductoId = Convert.ToInt32(reader["ProductoId"])
                            };
                        }
                    }
                }
            }
            return compra;
        }

        // 3. Agregar una nueva compra
        public async Task AddAsync(Compra compra)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarCompra", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaCompra", compra.FechaCompra);
                    cmd.Parameters.AddWithValue("@Estado", compra.Estado ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProductoId", compra.ProductoId);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Actualizar una compra existente
        public async Task UpdateAsync(Compra compra)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ActualizarCompra", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", compra.Id);
                    cmd.Parameters.AddWithValue("@FechaCompra", compra.FechaCompra);
                    cmd.Parameters.AddWithValue("@Estado", compra.Estado ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProductoId", compra.ProductoId);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Eliminar una compra por ID
        public async Task DeleteAsync(int id)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_EliminarCompra", conn))
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