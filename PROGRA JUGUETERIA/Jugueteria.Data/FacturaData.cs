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
    public class FacturasData : IFacturasData
    {
        private readonly Conexion _conexion = new Conexion();

        // 1. Obtener todas las facturas
        public async Task<IEnumerable<Facturas>> GetAllAsync()
        {
            var lista = new List<Facturas>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerFacturas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Facturas
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Numero_Factura = reader["Numero_Factura"]?.ToString()!,
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                                Totalneto = Convert.ToDecimal(reader["Totalneto"]),
                                ClienteId = Convert.ToInt32(reader["ClienteId"]),
                                EmpleadoId = Convert.ToInt32(reader["EmpleadoId"]),
                                ImpuestoId = Convert.ToInt32(reader["ImpuestoId"]),
                                MetodoPagoId = Convert.ToInt32(reader["MetodoPagoId"]),
                                Estado = reader["Estado"]?.ToString()!
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 2. Obtener una factura por ID
        public async Task<Facturas?> GetByIdAsync(int id)
        {
            Facturas? factura = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerFacturaPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            factura = new Facturas
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Numero_Factura = reader["Numero_Factura"]?.ToString()!,
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                                Totalneto = Convert.ToDecimal(reader["Totalneto"]),
                                ClienteId = Convert.ToInt32(reader["ClienteId"]),
                                EmpleadoId = Convert.ToInt32(reader["EmpleadoId"]),
                                ImpuestoId = Convert.ToInt32(reader["ImpuestoId"]),
                                MetodoPagoId = Convert.ToInt32(reader["MetodoPagoId"]),
                                Estado = reader["Estado"]?.ToString()!
                            };
                        }
                    }
                }
            }
            return factura;
        }

        // 3. Agregar una nueva factura
        public async Task AddAsync(Facturas factura)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarFactura", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Factura", factura.Numero_Factura ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Fecha", factura.Fecha);
                    cmd.Parameters.AddWithValue("@Subtotal", factura.Subtotal);
                    cmd.Parameters.AddWithValue("@Totalneto", factura.Totalneto);
                    cmd.Parameters.AddWithValue("@ClienteId", factura.ClienteId);
                    cmd.Parameters.AddWithValue("@EmpleadoId", factura.EmpleadoId);
                    cmd.Parameters.AddWithValue("@ImpuestoId", factura.ImpuestoId);
                    cmd.Parameters.AddWithValue("@MetodoPagoId", factura.MetodoPagoId);
                    cmd.Parameters.AddWithValue("@Estado", factura.Estado ?? (object)DBNull.Value);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Actualizar una factura existente
        public async Task UpdateAsync(Facturas factura)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ActualizarFactura", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", factura.Id);
                    cmd.Parameters.AddWithValue("@Numero_Factura", factura.Numero_Factura ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Fecha", factura.Fecha);
                    cmd.Parameters.AddWithValue("@Subtotal", factura.Subtotal);
                    cmd.Parameters.AddWithValue("@Totalneto", factura.Totalneto);
                    cmd.Parameters.AddWithValue("@ClienteId", factura.ClienteId);
                    cmd.Parameters.AddWithValue("@EmpleadoId", factura.EmpleadoId);
                    cmd.Parameters.AddWithValue("@ImpuestoId", factura.ImpuestoId);
                    cmd.Parameters.AddWithValue("@MetodoPagoId", factura.MetodoPagoId);
                    cmd.Parameters.AddWithValue("@Estado", factura.Estado ?? (object)DBNull.Value);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Eliminar una factura por ID
        public async Task DeleteAsync(int id)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_EliminarFactura", conn))
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