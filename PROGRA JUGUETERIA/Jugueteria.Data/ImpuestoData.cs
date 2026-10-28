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
    public class ImpuestoData : IImpuestoData
    {
        private readonly Conexion _conexion = new Conexion();

        // 1. Obtener todos los impuestos
        public async Task<IEnumerable<Impuesto>> GetAllAsync()
        {
            var lista = new List<Impuesto>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerImpuestos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Impuesto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"]?.ToString()!,
                                Porcentaje = Convert.ToDecimal(reader["Porcentaje"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 2. Obtener un impuesto por ID
        public async Task<Impuesto?> GetByIdAsync(int id)
        {
            Impuesto? impuesto = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerImpuestoPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            impuesto = new Impuesto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"]?.ToString()!,
                                Porcentaje = Convert.ToDecimal(reader["Porcentaje"])
                            };
                        }
                    }
                }
            }
            return impuesto;
        }

        // 3. Agregar un nuevo impuesto
        public async Task AddAsync(Impuesto impuesto)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarImpuesto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", impuesto.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Porcentaje", impuesto.Porcentaje);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Actualizar un impuesto existente
        public async Task UpdateAsync(Impuesto impuesto)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ActualizarImpuesto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", impuesto.Id);
                    cmd.Parameters.AddWithValue("@Nombre", impuesto.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Porcentaje", impuesto.Porcentaje);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Eliminar un impuesto por ID
        public async Task DeleteAsync(int id)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_EliminarImpuesto", conn))
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