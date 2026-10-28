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
    public class EdadData : IEdadData
    {
        private readonly Conexion _conexion = new Conexion();

        // 1. Obtener todos los rangos de edad
        public async Task<IEnumerable<Edad>> GetAllAsync()
        {
            var lista = new List<Edad>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerEdades", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Edad
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                RangoEdad = reader["RangoEdad"]?.ToString()!,
                                Advertencias = reader["Advertencias"]?.ToString()!
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 2. Obtener un rango de edad por ID
        public async Task<Edad> GetByIdAsync(int id)
        {
            Edad edad = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerEdadPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            edad = new Edad
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                RangoEdad = reader["RangoEdad"]?.ToString()!,
                                Advertencias = reader["Advertencias"]?.ToString()!
                            };
                        }
                    }
                }
            }
            return edad;
        }

        // 3. Agregar un nuevo rango de edad
        public async Task AddAsync(Edad edad)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarEdad", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RangoEdad", edad.RangoEdad ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Advertencias", edad.Advertencias ?? (object)DBNull.Value);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Actualizar un rango de edad existente
        public async Task UpdateAsync(Edad edad)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ActualizarEdad", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", edad.Id);
                    cmd.Parameters.AddWithValue("@RangoEdad", edad.RangoEdad ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Advertencias", edad.Advertencias ?? (object)DBNull.Value);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Eliminar un rango de edad por ID
        public async Task DeleteAsync(int id)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_EliminarEdad", conn))
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