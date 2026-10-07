using System;
using System.Collections.Generic;
using System.Text;

namespace Juguetería.Entity
{
    public class Producto
    { 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CateriaId { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Existencia { get; set; }
        public int MarcaId { get; set; }
        public int EdadId { get; set; }
        public int  MaterialId { get; set; }
        public string Etado { get; set; }
    }
}
