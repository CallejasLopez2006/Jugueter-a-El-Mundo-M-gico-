using System;
using System.Collections.Generic;
using System.Text;

namespace Juguetería.Entity
{
   public class Stock
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int ProductoId { get; set; }
    }
}
