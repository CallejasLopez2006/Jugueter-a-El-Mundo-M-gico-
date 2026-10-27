using System;
using System.Windows.Forms;
using Jugueteria.Servicio; 
using Jugueteria.Entity;  

namespace Juguetería_EL_Mundo_Mágico_
{
    public partial class Form1 : Form
    {

        private readonly ProductoServicio _productoServicio = new ProductoServicio();

        public Form1()
        {
            InitializeComponent();
        }

        private void MaterialId_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Productos.DataSource = _productoServicio.ListarProductos();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                Producto nuevoProducto = new Producto
                {
                    Nombre = Nombretxt.Text,
                    PrecioUnitario = Convert.ToDecimal(PrecioUnitariotxt.Text),
                    Existencia = Convert.ToInt32(ExistenciaStocktxt.Text),
                    CategoriaId = Convert.ToInt32(Categoriatxt.Text),
                    MarcaId = Convert.ToInt32(MarcaIdtxt.Text),
                    EdadId = Convert.ToInt32(EdadIdtxt.Text),
                    MaterialId = Convert.ToInt32(MaterialId.Text),
                    Estado = EstadoIdtxt.Text
                };

                
                if (_productoServicio.GuardarProducto(nuevoProducto))
                {
                    MessageBox.Show("Producto Guardado");

                    
                    Productos.DataSource = _productoServicio.ListarProductos();

                    
                    Nombretxt.Clear();
                    PrecioUnitariotxt.Clear();
                    ExistenciaStocktxt.Clear();
                    Categoriatxt.Clear();
                    MarcaIdtxt.Clear();
                    EdadIdtxt.Clear();
                    MaterialId.Clear();
                    EstadoIdtxt.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Revisa los datos ingresados. Error: " + ex.Message);
            }
        }
    }
}