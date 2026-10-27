using System;
using System.Collections.Generic;
using System.Text;

namespace Juguetería.Entity
{
    public class Detalle_Compra
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
    }
}
