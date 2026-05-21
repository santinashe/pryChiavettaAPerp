using System;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public partial class FormBienvenida : Form
    {
        // Variables para almacenar los datos del usuario
        private string nombreUsuario;
        private string rolUsuario;

        // Constructor que recibe los datos del usuario
        public FormBienvenida(string usuario, string rol)
        {
            InitializeComponent();
            nombreUsuario = usuario;
            rolUsuario = rol;
        }

        // Evento cuando carga el formulario
        private void FormBienvenida_Load(object sender, EventArgs e)
        {
            // Mostrar la información del usuario
            MostrarInformacionUsuario();
        }

        // Método para mostrar la información en los labels
        private void MostrarInformacionUsuario()
        {
            // Obtener la fecha y hora actual
            DateTime ahora = DateTime.Now;

            // Llenar los labels con la información
            lblFecha.Text = "Fecha: " + ahora.ToString("dd/MM/yyyy");
            lblHora.Text = "Hora: " + ahora.ToString("HH:mm:ss");
            lblUsuario.Text = "Usuario: " + nombreUsuario;
            lblRol.Text = "Rol: " + rolUsuario;
        }

        // Evento del botón Cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           FormPersonal formPersonal = new FormPersonal();
            formPersonal.ShowDialog();
        }
    }
}
