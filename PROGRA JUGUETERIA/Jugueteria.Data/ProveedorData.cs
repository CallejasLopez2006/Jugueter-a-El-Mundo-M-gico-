using Juguetería;
using Jugueteria.Entity;
using Juguetería.Entity.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Jugueteria.Data
{
    public class ProveedorData : IProveedorData
    {
        private readonly Conexion _conexion = new Conexion();

        // 1. Obtener todos los proveedores
        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            var lista = new List<Proveedor>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerProveedores", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Proveedor
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"]?.ToString()!,
                                NIT = reader["NIT"]?.ToString()!,
                                Contacto = reader["Contacto"]?.ToString()!,
                                Email = reader["Email"]?.ToString()!,
                                Telefono = reader["Telefono"]?.ToString()!
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 2. Obtener un proveedor por ID
        public async Task<Proveedor> GetByIdAsync(int id)
        {
            Proveedor proveedor = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerProveedorPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            proveedor = new Proveedor
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"]?.ToString()!,
                                NIT = reader["NIT"]?.ToString()!,
                                Contacto = reader["Contacto"]?.ToString()!,
                                Email = reader["Email"]?.ToString()!,
                                Telefono = reader["Telefono"]?.ToString()!
                            };
                        }
                    }
                }
            }
            return proveedor;
        }

        // 3. Agregar un nuevo proveedor
        public async Task AddAsync(Proveedor proveedor)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarProveedor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NIT", proveedor.NIT ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Contacto", proveedor.Contacto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", proveedor.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono ?? (object)DBNull.Value);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Actualizar un proveedor existente
        public async Task UpdateAsync(Proveedor proveedor)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ActualizarProveedor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", proveedor.Id);
                    cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NIT", proveedor.NIT ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Contacto", proveedor.Contacto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", proveedor.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono ?? (object)DBNull.Value);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Eliminar un proveedor por ID
        public async Task DeleteAsync(int id)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_EliminarProveedor", conn))
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