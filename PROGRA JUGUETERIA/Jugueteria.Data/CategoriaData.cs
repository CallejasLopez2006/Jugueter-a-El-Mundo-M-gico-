using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Jugueteria.Entity;

namespace Jugueteria.Data
{
    public class CategoriaData
    {
        private readonly Conexion _conexion = new Conexion();

        
        public List<Categoria> ObtenerTodas()
        {
            var lista = new List<Categoria>();

            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_ObtenerCategorias", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
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

        
        public bool Insertar(Categoria categoria)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand("sp_InsertarCategoria", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    cmd.Parameters.AddWithValue("@Estado", categoria.Estado);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}