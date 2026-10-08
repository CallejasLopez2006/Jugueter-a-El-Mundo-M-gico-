using System;
using System.Collections.Generic;
using System.Text;

namespace Juguetería.Entity
{
    public class Inventario
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int ProductoId { get; set; }
    }
}
