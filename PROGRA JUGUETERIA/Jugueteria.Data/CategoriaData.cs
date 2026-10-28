using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Jugueteria.Entity;
using Juguetería.Entity.Interfaces;

namespace Jugueteria.Data
{
    public class CategoriaData : ICategoriaData
    {
        private readonly Conexion _conexion = new Conexion();

        // 1. Obtener todas las categorías
        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            var lista = new List<Categoria>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerCategorias", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Categoria
                            {
                                CategoriaId = Convert.ToInt32(reader["CategoriaId"]),
                                Nombre = reader["Nombre"].ToString(),
                                Estado = reader["Estado"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 2. Obtener una categoría por su ID
        public async Task<Categoria> GetByIdAsync(int id)
        {
            Categoria categoria = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerCategoriaPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoriaId", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            categoria = new Categoria
                            {
                                CategoriaId = Convert.ToInt32(reader["CategoriaId"]),
                                Nombre = reader["Nombre"].ToString(),
                                Estado = reader["Estado"].ToString()
                            };
                        }
                    }
                }
            }
            return categoria;
        }

        // 3. Insertar/Agregar una nueva categoría
        public async Task AddAsync(Categoria categoria)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarCategoria", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    cmd.Parameters.AddWithValue("@Estado", categoria.Estado);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Actualizar una categoría existente
        public async Task UpdateAsync(Categoria categoria)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ActualizarCategoria", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoriaId", categoria.CategoriaId);
                    cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    cmd.Parameters.AddWithValue("@Estado", categoria.Estado);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Eliminar una categoría por ID
        public async Task DeleteAsync(int id)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_EliminarCategoria", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoriaId", id);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}