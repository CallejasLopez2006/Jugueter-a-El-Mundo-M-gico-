using System;
using System.Collections.Generic;
using Jugueteria.Entity;
using Jugueteria.Data;

namespace Jugueteria.Servicio
{
    public class CategoriaServicio
    {
        private readonly CategoriaData _categoriaData = new CategoriaData();

        public List<Categoria> ListarCategorias()
        {
            return _categoriaData.ObtenerTodas();
        }

        public bool GuardarCategoria(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nombre))
            {
                throw new ArgumentException("El nombre de la categoría es obligatorio.");
            }

            return _categoriaData.Insertar(categoria);
        }
    }
}