using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juguetería_EL_MUNDO_MÁGICO
{
    public partial class FrmMarca : Form
    {
        private int _idSeleccionado = 0;

        public FrmMarca()
        {
            InitializeComponent();
        }

        private async void FrmMarca_Load(object sender, EventArgs e)
        {
            await CargarGridAsync();
        }

        private async Task CargarGridAsync()
        {
            await Task.CompletedTask;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreMarca.Text))
            {
                MessageBox.Show("Por favor, ingresa el nombre de la marca.");
                return;
            }

            if (_idSeleccionado == 0)
            {
                MessageBox.Show("¡Marca guardada con éxito!");
            }
            else
            {
                MessageBox.Show("¡Marca actualizada con éxito!");
                _idSeleccionado = 0;
            }

            LimpiarCampos();
        }

        private void dgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvMarcas.Rows[e.RowIndex];
                if (fila.Cells["Id"].Value != null)
                {
                    _idSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);
                    txtNombreMarca.Text = fila.Cells["NombreMarca"].Value?.ToString() ?? string.Empty;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona una marca de la tabla para eliminar.");
                return;
            }

            if (MessageBox.Show("¿Estás seguro de eliminar esta marca?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("¡Marca eliminada!");
                LimpiarCampos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreMarca.Clear();
            _idSeleccionado = 0;
        }
    }
}