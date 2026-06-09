using System;
using System.Data;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public partial class frmGestionUsuarios : Form
    {
        private DataTable usuarios;

        public frmGestionUsuarios()
        {
            InitializeComponent();
            cmbRol.Items.Add(PermisosServicio.RolAdministrador);
            cmbRol.Items.Add(PermisosServicio.RolSupervisor);
            cmbRol.Items.Add(PermisosServicio.RolOperador);
            EnterNavigationHelper.Activar(this, btnAlta);
            Load += frmGestionUsuarios_Load;
        }

        private void frmGestionUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                PermisosServicio.Exigir(
                    PermisosServicio.PuedeGestionarUsuarios(),
                    "No tiene permisos para gestionar usuarios.");

                UsuarioServicio.AsegurarRolesBase();
                AuditoriaServicio.RegistrarAuditoria("frmGestionUsuarios", "Apertura de formulario");
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("frmGestionUsuarios", "Error", ex.Message);
                MessageBox.Show(ex.Message, "Gestión de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void CargarUsuarios()
        {
            usuarios = UsuarioServicio.ObtenerUsuarios();
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            if (usuarios == null)
            {
                return;
            }

            string filtro = txtBuscar.Text.Trim().Replace("'", "''");
            DataView vista = usuarios.DefaultView;

            if (filtro == "")
            {
                vista.RowFilter = "";
            }
            else
            {
                vista.RowFilter =
                    "Convert([Nombre], 'System.String') LIKE '%" + filtro + "%' OR " +
                    "Convert([Apellido], 'System.String') LIKE '%" + filtro + "%' OR " +
                    "Convert([Dni], 'System.String') LIKE '%" + filtro + "%' OR " +
                    "Convert([Mail], 'System.String') LIKE '%" + filtro + "%' OR " +
                    "Convert([Perfil], 'System.String') LIKE '%" + filtro + "%'";
            }

            dgvUsuarios.DataSource = vista;
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null || dgvUsuarios.CurrentRow.DataBoundItem == null)
            {
                return;
            }

            DataRowView fila = dgvUsuarios.CurrentRow.DataBoundItem as DataRowView;

            if (fila == null)
            {
                return;
            }

            txtId.Text = fila["IdUsuario"].ToString();
            txtNombre.Text = fila["Nombre"].ToString();
            txtApellido.Text = fila["Apellido"].ToString();
            txtDni.Text = fila["Dni"].ToString();
            txtMail.Text = fila["Mail"].ToString();
            txtContrasenia.Text = fila["Contraseña"].ToString();
            cmbRol.Text = PermisosServicio.NormalizarRol(fila["Perfil"].ToString());
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioServicio.Alta(
                    txtNombre.Text,
                    txtApellido.Text,
                    txtDni.Text,
                    txtMail.Text,
                    txtContrasenia.Text,
                    cmbRol.Text);

                CargarUsuarios();
                Limpiar();
                MessageBox.Show("Usuario dado de alta correctamente.", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("frmGestionUsuarios", "Error", ex.Message);
                MessageBox.Show(ex.Message, "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioServicio.Modificar(
                    ObtenerIdSeleccionado(),
                    txtNombre.Text,
                    txtApellido.Text,
                    txtDni.Text,
                    txtMail.Text,
                    txtContrasenia.Text,
                    cmbRol.Text);

                CargarUsuarios();
                MessageBox.Show("Usuario modificado correctamente.", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("frmGestionUsuarios", "Error", ex.Message);
                MessageBox.Show(ex.Message, "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ObtenerIdSeleccionado();

                DialogResult respuesta = MessageBox.Show(
                    "¿Confirma la baja del usuario seleccionado?",
                    "Usuarios",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                UsuarioServicio.Baja(id);
                CargarUsuarios();
                Limpiar();
                MessageBox.Show("Usuario eliminado correctamente.", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("frmGestionUsuarios", "Error", ex.Message);
                MessageBox.Show(ex.Message, "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private int ObtenerIdSeleccionado()
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                return 0;
            }

            return id;
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtMail.Clear();
            txtContrasenia.Clear();
            cmbRol.SelectedIndex = -1;
            txtNombre.Focus();
        }
    }
}
