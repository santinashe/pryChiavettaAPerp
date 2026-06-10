using System;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public partial class frmAcciones : Form
    {
        public frmAcciones()
        {
            InitializeComponent();
            EnterNavigationHelper.Activar(this);
            Load += frmAcciones_Load;
            button2.Click += button2_Click;
            button5.Click += button5_Click;
        }

        #region Eventos

        private void frmAcciones_Load(object sender, EventArgs e)
        {
            label2.Text = SesionActual.Nombre + " - " + PermisosServicio.NormalizarRol(SesionActual.Rol);
            button2.Text = "Usuarios";
            AplicarPermisos();
            AuditoriaServicio.RegistrarAuditoria("frmAcciones", "Apertura de formulario");
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PermisosServicio.Exigir(PermisosServicio.PuedeGestionarPersonal(), "No tiene permisos para abrir Personal.");
                AuditoriaServicio.RegistrarAuditoria("frmAcciones", "Apertura de formulario", "frmPersonal");
                frmPersonal personalForm = new frmPersonal();
                personalForm.ShowDialog();
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("frmAcciones", "Error", ex.Message);
                MessageBox.Show(ex.Message, "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                PermisosServicio.Exigir(PermisosServicio.PuedeGestionarUsuarios(), "No tiene permisos para gestionar usuarios.");
                frmGestionUsuarios usuarios = new frmGestionUsuarios();
                usuarios.ShowDialog();
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("frmAcciones", "Error", ex.Message);
                MessageBox.Show(ex.Message, "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                PermisosServicio.Exigir(PermisosServicio.PuedeVerAuditoria(), "No tiene permisos para consultar auditoría.");
                frmGestionAuditoria auditoria = new frmGestionAuditoria();
                auditoria.ShowDialog();
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("frmAcciones", "Error", ex.Message);
                MessageBox.Show(ex.Message, "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AuditoriaServicio.RegistrarAuditoria("frmAcciones", "Cierre de formulario");
            Close();
        }
        

        #endregion

        #region Permisos

        private void AplicarPermisos()
        {
            PermisosServicio.AplicarPermiso(button1, PermisosServicio.PuedeGestionarPersonal());
            PermisosServicio.AplicarPermiso(button2, PermisosServicio.PuedeGestionarUsuarios());
            PermisosServicio.AplicarPermiso(button3, PermisosServicio.PuedeVerAuditoria());
        }

        #endregion

        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
