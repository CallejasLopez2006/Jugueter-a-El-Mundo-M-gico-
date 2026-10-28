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
    public class Detalle_FacturaData : IDetalle_FacturaData
    {
        private readonly Conexion _conexion = new Conexion();

        // 1. Obtener todos los detalles de factura
        public async Task<IEnumerable<Detalle_Factura>> GetAllAsync()
        {
            var lista = new List<Detalle_Factura>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerDetallesFactura", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Detalle_Factura
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FacturaId = Convert.ToInt32(reader["FacturaId"]),
                                ProductoId = Convert.ToInt32(reader["ProductoId"]),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                                Descuento = Convert.ToDecimal(reader["Descuento"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 2. Obtener un detalle de factura por ID
        public async Task<Detalle_Factura> GetByIdAsync(int id)
        {
            Detalle_Factura detalle = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerDetalleFacturaPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            detalle = new Detalle_Factura
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FacturaId = Convert.ToInt32(reader["FacturaId"]),
                                ProductoId = Convert.ToInt32(reader["ProductoId"]),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                                Descuento = Convert.ToDecimal(reader["Descuento"])
                            };
                        }
                    }
                }
            }
            return detalle;
        }

        // 3. Agregar un nuevo detalle de factura
        public async Task AddAsync(Detalle_Factura detalleFactura)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarDetalleFactura", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FacturaId", detalleFactura.FacturaId);
                    cmd.Parameters.AddWithValue("@ProductoId", detalleFactura.ProductoId);
                    cmd.Parameters.AddWithValue("@Cantidad", detalleFactura.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", detalleFactura.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@Descuento", detalleFactura.Descuento);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Actualizar un detalle de factura existente
        public async Task UpdateAsync(Detalle_Factura detalleFactura)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ActualizarDetalleFactura", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", detalleFactura.Id);
                    cmd.Parameters.AddWithValue("@FacturaId", detalleFactura.FacturaId);
                    cmd.Parameters.AddWithValue("@ProductoId", detalleFactura.ProductoId);
                    cmd.Parameters.AddWithValue("@Cantidad", detalleFactura.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", detalleFactura.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@Descuento", detalleFactura.Descuento);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Eliminar un detalle de factura por ID
        public async Task DeleteAsync(int id)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_EliminarDetalleFactura", conn))
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