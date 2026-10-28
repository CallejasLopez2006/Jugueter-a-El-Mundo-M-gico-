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
    public class StockData : IStockData
    {
        private readonly Conexion _conexion = new Conexion();

        // 1. Obtener todos los registros de stock
        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            var lista = new List<Stock>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerStocks", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Stock
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Tipo = reader["Tipo"]?.ToString()!,
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                ProductoId = Convert.ToInt32(reader["ProductoId"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 2. Obtener un registro de stock por ID
        public async Task<Stock?> GetByIdAsync(int id)
        {
            Stock? stock = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerStockPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            stock = new Stock
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Tipo = reader["Tipo"]?.ToString()!,
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                ProductoId = Convert.ToInt32(reader["ProductoId"])
                            };
                        }
                    }
                }
            }
            return stock;
        }

        // 3. Agregar un nuevo registro de stock
        public async Task AddAsync(Stock stock)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarStock", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Tipo", stock.Tipo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cantidad", stock.Cantidad);
                    cmd.Parameters.AddWithValue("@Fecha", stock.Fecha);
                    cmd.Parameters.AddWithValue("@ProductoId", stock.ProductoId);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Actualizar un registro de stock existente
        public async Task UpdateAsync(Stock stock)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ActualizarStock", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", stock.Id);
                    cmd.Parameters.AddWithValue("@Tipo", stock.Tipo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cantidad", stock.Cantidad);
                    cmd.Parameters.AddWithValue("@Fecha", stock.Fecha);
                    cmd.Parameters.AddWithValue("@ProductoId", stock.ProductoId);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Eliminar un registro de stock por ID
        public async Task DeleteAsync(int id)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_EliminarStock", conn))
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