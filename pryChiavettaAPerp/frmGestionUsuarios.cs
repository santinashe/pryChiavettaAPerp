using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public class frmGestionUsuarios : Form
    {
        #region Controles

        private DataGridView dgvUsuarios;
        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDni;
        private TextBox txtMail;
        private TextBox txtContrasenia;
        private ComboBox cmbRol;
        private TextBox txtBuscar;
        private Button btnAlta;
        private Button btnModificar;
        private Button btnBaja;
        private Button btnLimpiar;
        private Button btnActualizar;

        #endregion

        private DataTable usuarios;

        public frmGestionUsuarios()
        {
            InitializeComponent();
            Load += frmGestionUsuarios_Load;
        }

        private void InitializeComponent()
        {
            Text = "Gestión de usuarios";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(980, 560);
            BackColor = Color.White;

            Label titulo = new Label();
            titulo.Text = "Gestión de usuarios";
            titulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titulo.Location = new Point(20, 15);
            titulo.AutoSize = true;

            dgvUsuarios = new DataGridView();
            dgvUsuarios.Location = new Point(20, 80);
            dgvUsuarios.Size = new Size(620, 430);
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;

            Label lblBuscar = CrearLabel("Buscar", 20, 52);
            txtBuscar = CrearTextBox(80, 49, 250);
            txtBuscar.TextChanged += txtBuscar_TextChanged;

            btnActualizar = CrearBoton("Actualizar", 350, 47, 110);
            btnActualizar.Click += btnActualizar_Click;

            int x = 670;
            int y = 80;
            txtId = CrearTextBox(x + 120, y, 180);
            txtId.ReadOnly = true;
            txtId.BackColor = Color.Gainsboro;
            Controls.Add(CrearLabel("ID", x, y + 4));
            Controls.Add(txtId);

            y += 38;
            txtNombre = CrearTextBox(x + 120, y, 180);
            Controls.Add(CrearLabel("Nombre", x, y + 4));
            Controls.Add(txtNombre);

            y += 38;
            txtApellido = CrearTextBox(x + 120, y, 180);
            Controls.Add(CrearLabel("Apellido", x, y + 4));
            Controls.Add(txtApellido);

            y += 38;
            txtDni = CrearTextBox(x + 120, y, 180);
            Controls.Add(CrearLabel("DNI", x, y + 4));
            Controls.Add(txtDni);

            y += 38;
            txtMail = CrearTextBox(x + 120, y, 180);
            Controls.Add(CrearLabel("Mail", x, y + 4));
            Controls.Add(txtMail);

            y += 38;
            txtContrasenia = CrearTextBox(x + 120, y, 180);
            txtContrasenia.PasswordChar = '*';
            Controls.Add(CrearLabel("Contraseña", x, y + 4));
            Controls.Add(txtContrasenia);

            y += 38;
            cmbRol = new ComboBox();
            cmbRol.Location = new Point(x + 120, y);
            cmbRol.Size = new Size(180, 23);
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Items.Add(PermisosServicio.RolAdministrador);
            cmbRol.Items.Add(PermisosServicio.RolSupervisor);
            cmbRol.Items.Add(PermisosServicio.RolOperador);
            Controls.Add(CrearLabel("Rol", x, y + 4));
            Controls.Add(cmbRol);

            y += 55;
            btnAlta = CrearBoton("Alta", x, y, 140);
            btnAlta.Click += btnAlta_Click;
            btnModificar = CrearBoton("Modificar", x + 160, y, 140);
            btnModificar.Click += btnModificar_Click;

            y += 45;
            btnBaja = CrearBoton("Baja", x, y, 140);
            btnBaja.Click += btnBaja_Click;
            btnLimpiar = CrearBoton("Limpiar", x + 160, y, 140);
            btnLimpiar.Click += btnLimpiar_Click;

            Controls.Add(titulo);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnActualizar);
            Controls.Add(dgvUsuarios);
            Controls.Add(btnAlta);
            Controls.Add(btnModificar);
            Controls.Add(btnBaja);
            Controls.Add(btnLimpiar);
        }

        private Label CrearLabel(string texto, int x, int y)
        {
            Label label = new Label();
            label.Text = texto;
            label.Location = new Point(x, y);
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            return label;
        }

        private TextBox CrearTextBox(int x, int y, int ancho)
        {
            TextBox textBox = new TextBox();
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(ancho, 23);
            return textBox;
        }

        private Button CrearBoton(string texto, int x, int y, int ancho)
        {
            Button boton = new Button();
            boton.Text = texto;
            boton.Location = new Point(x, y);
            boton.Size = new Size(ancho, 34);
            boton.BackColor = Color.FromArgb(240, 242, 245);
            boton.FlatStyle = FlatStyle.Flat;
            return boton;
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
