using System;
using System.Collections.Generic;
using Jugueteria.Entity;
using Jugueteria.Data;

namespace Jugueteria.Servicio
{
    public class ProductoServicio
    {
        private readonly ProductoData _productoData = new ProductoData();

        public List<Producto> ListarProductos()
        {
            return _productoData.ObtenerTodos();
        }

        public bool GuardarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                throw new ArgumentException("El nombre del producto es obligatorio.");
            }

            if (producto.PrecioUnitario <= 0)
            {
                throw new ArgumentException("El precio unitario debe ser mayor a 0.");
            }

            if (producto.Existencia < 0)
            {
                throw new ArgumentException("La existencia no puede ser negativa.");
            }

            if (producto.CategoriaId <= 0)
            {
                throw new ArgumentException("Debe seleccionar una categoría válida.");
            }

            return _productoData.Insertar(producto);
        }
    }
}