using System;
using System.Collections.Generic;
using System.Text;

namespace Juguetería.Entity
{
    public class Facturas
    {
        public int Id { get; set; }
        public string Numero_Factura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Totalneto { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int ImpuestoId { get; set; }
        public int MetodoPagoId { get; set; }
        public string Estado { get; set; }
    }
}
