using Juguetería;
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
    public class MetodoPagoData : IMetodoPagoData
    {
        private readonly Conexion _conexion = new Conexion();

        // 1. Obtener todos los métodos de pago
        public async Task<IEnumerable<MetodoPago>> GetAllAsync()
        {
            var lista = new List<MetodoPago>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerMetodosPago", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new MetodoPago
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"]?.ToString()!,
                                Descrpcion = reader["Descrpcion"]?.ToString()!,
                                Estado = reader["Estado"]?.ToString()!
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 2. Obtener un método de pago por ID
        public async Task<MetodoPago?> GetByIdAsync(int id)
        {
            MetodoPago? metodoPago = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerMetodoPagoPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            metodoPago = new MetodoPago
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"]?.ToString()!,
                                Descrpcion = reader["Descrpcion"]?.ToString()!,
                                Estado = reader["Estado"]?.ToString()!
                            };
                        }
                    }
                }
            }
            return metodoPago;
        }

        // 3. Agregar un nuevo método de pago
        public async Task AddAsync(MetodoPago metodoPago)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarMetodoPago", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", metodoPago.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Descrpcion", metodoPago.Descrpcion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", metodoPago.Estado ?? (object)DBNull.Value);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Actualizar un método de pago existente
        public async Task UpdateAsync(MetodoPago metodoPago)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ActualizarMetodoPago", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", metodoPago.Id);
                    cmd.Parameters.AddWithValue("@Nombre", metodoPago.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Descrpcion", metodoPago.Descrpcion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", metodoPago.Estado ?? (object)DBNull.Value);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Eliminar un método de pago por ID
        public async Task DeleteAsync(int id)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_EliminarMetodoPago", conn))
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