using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public partial class frmPrinicipal : Form
    {
        #region Campos

        private ConexionBD conexionBD;
        private int intentosFallidos = 0;
        private int maximoIntentos = 3;

        #endregion

        public frmPrinicipal()
        {
            InitializeComponent();
            conexionBD = new ConexionBD();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            ActualizarEstadoConexion();

            Timer timerConexion = new Timer();
            timerConexion.Interval = 2000;
            timerConexion.Tick += (s, args) => ActualizarEstadoConexion();
            timerConexion.Start();
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkMostrar.Checked ? '\0' : '*';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, completa todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable datosUsuario = ObtenerDatosUsuario(usuario, password);

                if (datosUsuario.Rows.Count > 0)
                {
                    CargarSesion(datosUsuario.Rows[0]);
                    AuditoriaServicio.RegistrarAuditoria("frmPrinicipal", "Inicio de sesión", "Login correcto");

                    frmBienvenida formBienvenida = new frmBienvenida(
                        SesionActual.Nombre + " " + SesionActual.Apellido,
                        SesionActual.Rol);

                    Hide();
                    formBienvenida.ShowDialog();
                    Show();

                    txtUsuario.Clear();
                    txtPassword.Clear();
                    intentosFallidos = 0;
                    return;
                }

                RegistrarLoginFallido(usuario);
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("frmPrinicipal", "Error", ex.Message);
                MessageBox.Show("Error al validar credenciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
        }

        private void lblEstadoConexion_Click(object sender, EventArgs e)
        {
        }

        #endregion

        #region Login

        private DataTable ObtenerDatosUsuario(string usuario, string password)
        {
            string consulta = @"SELECT TOP 1 u.[IdUsuario], u.[Nombre], u.[Apellido], u.[Mail], u.[Contraseña], p.[Nombre] AS [Perfil]
                FROM ([Usuario] u
                LEFT JOIN [RelacionUsuarioPerfil] r ON CStr(u.[IdUsuario]) = r.[IdUsuario])
                LEFT JOIN [Perfil] p ON CStr(p.[IdPerfil]) = r.[IdPerfil]
                WHERE u.[Nombre] = ? AND u.[Contraseña] = ?";

            return OperacionesBD.ObtenerDatos(consulta, new OleDbParameter[]
            {
                new OleDbParameter("?", usuario),
                new OleDbParameter("?", password)
            });
        }

        private void CargarSesion(DataRow fila)
        {
            SesionActual.IdUsuario = Convert.ToInt32(fila["IdUsuario"]);
            SesionActual.Nombre = fila["Nombre"].ToString();
            SesionActual.Apellido = fila["Apellido"].ToString();
            SesionActual.Mail = fila["Mail"].ToString();
            SesionActual.Rol = PermisosServicio.NormalizarRol(fila["Perfil"].ToString());
            SesionActual.FechaIngreso = DateTime.Now;
        }

        private void RegistrarLoginFallido(string usuario)
        {
            intentosFallidos++;
            int intentosRestantes = maximoIntentos - intentosFallidos;

            AuditoriaServicio.RegistrarAuditoria("frmPrinicipal", "Error", "Login fallido para usuario: " + usuario);

            if (intentosRestantes > 0)
            {
                MessageBox.Show(
                    "Usuario o contraseña incorrectos.\nIntentos restantes: " + intentosRestantes,
                    "Error de login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtPassword.Clear();
                return;
            }

            MessageBox.Show(
                "Cantidad máxima de intentos superada.\nLa aplicación se cerrará.",
                "Acceso denegado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop);

            Application.Exit();
        }

        #endregion

        #region Conexion

        private void ActualizarEstadoConexion()
        {
            if (conexionBD.VerificarConexion())
            {
                lblEstadoConexion.Text = "Base de datos conectada";
                lblEstadoConexion.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblEstadoConexion.Text = "Base de datos desconectada";
                lblEstadoConexion.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion
    }
}