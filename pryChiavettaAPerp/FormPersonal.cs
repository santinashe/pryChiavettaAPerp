using System;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public partial class FormPersonal : Form
    {
        public FormPersonal()
        {
            InitializeComponent();
        }

        private void FormPersonal_Load(object sender, EventArgs e)
        {
            CargarLocalidades();
            CargarProvincias();
        }

        private void CargarLocalidades()
        {
        }
            

        private void CargarProvincias()
        {
           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(maskedTextBox2.Text))
            {
                MessageBox.Show("Por favor, ingrese el DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Por favor, ingrese el Apellido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el Nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, ingrese la Dirección.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtGeo.Text))
            {
                MessageBox.Show("Por favor, ingrese la Geolocalización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (    cmbLocalidad.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una Localidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbProvincia.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una Provincia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            maskedTextBox2.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtGeo.Text = "";
            cmbLocalidad.SelectedIndex = -1;
            cmbProvincia.SelectedIndex = -1;
        }

        private void gbDomicilio_Enter(object sender, EventArgs e)
        {

        }

        private void gbUbicacion_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
