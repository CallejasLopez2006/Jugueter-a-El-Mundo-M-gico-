using System;
using System.Collections.Generic;
using System.Text;

namespace Juguetería.Entity
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime FechaCompra { get; set; }
        public string Estado { get; set; }
        public int ProductoId { get; set; }
    }
}
