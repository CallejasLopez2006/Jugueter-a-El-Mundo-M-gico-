using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Jugueteria.Entity;
using Juguetería.Entity;
using Juguetería.Entity.Interfaces;

namespace Jugueteria.Data
{
    public class InventarioData : IInventarioData
    {
        private readonly Conexion _conexion = new Conexion();

        // 1. Obtener todos los registros de inventario
        public async Task<IEnumerable<Inventario>> GetAllAsync()
        {
            var lista = new List<Inventario>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerInventarios", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Inventario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                ProductoId = Convert.ToInt32(reader["ProductoId"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 2. Obtener un registro de inventario por ID
        public async Task<Inventario?> GetByIdAsync(int id)
        {
            Inventario? inventario = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerInventarioPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            inventario = new Inventario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                ProductoId = Convert.ToInt32(reader["ProductoId"])
                            };
                        }
                    }
                }
            }
            return inventario;
        }

        // 3. Agregar un nuevo registro de inventario
        public async Task AddAsync(Inventario inventario)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarInventario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Stock", inventario.Stock);
                    cmd.Parameters.AddWithValue("@ProductoId", inventario.ProductoId);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Actualizar un registro de inventario existente
        public async Task UpdateAsync(Inventario inventario)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ActualizarInventario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", inventario.Id);
                    cmd.Parameters.AddWithValue("@Stock", inventario.Stock);
                    cmd.Parameters.AddWithValue("@ProductoId", inventario.ProductoId);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Eliminar un registro de inventario por ID
        public async Task DeleteAsync(int id)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_EliminarInventario", conn))
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