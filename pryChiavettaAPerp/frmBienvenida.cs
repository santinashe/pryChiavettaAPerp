using System;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public partial class frmBienvenida : Form
    {
        #region Campos

        private string nombreUsuario;
        private string rolUsuario;

        #endregion

        public frmBienvenida(string usuario, string rol)
        {
            InitializeComponent();
            nombreUsuario = usuario;
            rolUsuario = PermisosServicio.NormalizarRol(rol);
            EnterNavigationHelper.Activar(this, bntIngresar);
        }

        #region Eventos

        private void FormBienvenida_Load(object sender, EventArgs e)
        {
            MostrarInformacionUsuario();
            AuditoriaServicio.RegistrarAuditoria("frmBienvenida", "Apertura de formulario");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            AuditoriaServicio.RegistrarAuditoria("frmBienvenida", "Cierre de sesión");
            SesionActual.CerrarSesion();
            Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                frmAcciones accionesForm = new frmAcciones();
                accionesForm.ShowDialog();
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("frmBienvenida", "Error", ex.Message);
                MessageBox.Show("Error al abrir el menú: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Pantalla

        private void MostrarInformacionUsuario()
        {
            DateTime ahora = DateTime.Now;

            lblFecha.Text = "Fecha: " + ahora.ToString("dd/MM/yyyy");
            lblHora.Text = "Hora: " + ahora.ToString("HH:mm:ss");
            lblUsuario.Text = "Usuario: " + nombreUsuario;
            lblRol.Text = "Rol: " + rolUsuario;
        }

        #endregion
    }
}
