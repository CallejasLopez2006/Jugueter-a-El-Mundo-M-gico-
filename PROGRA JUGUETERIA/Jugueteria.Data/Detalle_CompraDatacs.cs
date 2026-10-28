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
    public class Detalle_CompraData : IDetalle_CompraData
    {
        private readonly Conexion _conexion = new Conexion();

        // 1. Obtener todos los detalles de compra
        public async Task<IEnumerable<Detalle_Compra>> GetAllAsync()
        {
            var lista = new List<Detalle_Compra>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerDetalleCompras", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Detalle_Compra
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                                CompraId = Convert.ToInt32(reader["CompraId"]),
                                ProductoId = Convert.ToInt32(reader["ProductoId"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 2. Obtener un detalle de compra por ID
        public async Task<Detalle_Compra> GetByIdAsync(int id)
        {
            Detalle_Compra detalle = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerDetalleCompraPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            detalle = new Detalle_Compra
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                                CompraId = Convert.ToInt32(reader["CompraId"]),
                                ProductoId = Convert.ToInt32(reader["ProductoId"])
                            };
                        }
                    }
                }
            }
            return detalle;
        }

        // 3. Agregar un nuevo detalle de compra
        public async Task AddAsync(Detalle_Compra detalleCompra)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarDetalleCompra", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cantidad", detalleCompra.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", detalleCompra.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@CompraId", detalleCompra.CompraId);
                    cmd.Parameters.AddWithValue("@ProductoId", detalleCompra.ProductoId);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Actualizar un detalle de compra existente
        public async Task UpdateAsync(Detalle_Compra detalleCompra)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ActualizarDetalleCompra", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", detalleCompra.Id);
                    cmd.Parameters.AddWithValue("@Cantidad", detalleCompra.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", detalleCompra.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@CompraId", detalleCompra.CompraId);
                    cmd.Parameters.AddWithValue("@ProductoId", detalleCompra.ProductoId);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Eliminar un detalle de compra por ID
        public async Task DeleteAsync(int id)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_EliminarDetalleCompra", conn))
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