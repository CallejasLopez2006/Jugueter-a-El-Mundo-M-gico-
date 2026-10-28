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
    public class EmpleadoData : IEmpleadoData
    {
        private readonly Conexion _conexion = new Conexion();

        // 1. Obtener todos los empleados
        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            var lista = new List<Empleado>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerEmpleados", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Empleado
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"]?.ToString()!,
                                Apellido = reader["Apellido"]?.ToString()!,
                                DUI = reader["DUI"]?.ToString()!,
                                Cargo = reader["Cargo"]?.ToString()!,
                                Usuario = reader["Usuario"]?.ToString()!
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 2. Obtener un empleado por ID
        public async Task<Empleado?> GetByIdAsync(int id)
        {
            Empleado? empleado = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerEmpleadoPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            empleado = new Empleado
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"]?.ToString()!,
                                Apellido = reader["Apellido"]?.ToString()!,
                                DUI = reader["DUI"]?.ToString()!,
                                Cargo = reader["Cargo"]?.ToString()!,
                                Usuario = reader["Usuario"]?.ToString()!
                            };
                        }
                    }
                }
            }
            return empleado;
        }

        // 3. Agregar un nuevo empleado
        public async Task AddAsync(Empleado empleado)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarEmpleado", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DUI", empleado.DUI ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cargo", empleado.Cargo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Usuario", empleado.Usuario ?? (object)DBNull.Value);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Actualizar un empleado existente
        public async Task UpdateAsync(Empleado empleado)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ActualizarEmpleado", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", empleado.Id);
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DUI", empleado.DUI ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cargo", empleado.Cargo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Usuario", empleado.Usuario ?? (object)DBNull.Value);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Eliminar un empleado por ID
        public async Task DeleteAsync(int id)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_EliminarEmpleado", conn))
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