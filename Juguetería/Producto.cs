namespace Jugueteria.Entity
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Existencia { get; set; }
        public int MarcaId { get; set; }
        public int EdadId { get; set; }
        public int MaterialId { get; set; }
        public string Estado { get; set; }
    }
}