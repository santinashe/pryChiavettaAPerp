using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public partial class frmPrinicipal : Form
    {
        // Variable para manejar la conexión a la base de datos
        private ConexionBD conexionBD;

        // Contador de intentos fallidos
        private int intentosFallidos = 0;
        private int maximoIntentos = 3;

        public frmPrinicipal()
        {
            InitializeComponent();
            conexionBD = new ConexionBD();
        }

        // Evento que se ejecuta cuando carga el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            // Configurar la contraseña para que se vea con asteriscos
            txtPassword.PasswordChar = '*';

            // Verificar el estado de la conexión cuando inicia
            ActualizarEstadoConexion();

            // Crear un Timer para actualizar el estado cada 2 segundos
            Timer timerConexion = new Timer();
            timerConexion.Interval = 2000;
            timerConexion.Tick += (s, args) => ActualizarEstadoConexion();
            timerConexion.Start();
        }

        // Método para actualizar el label del estado de la conexión
        private void ActualizarEstadoConexion()
        {
            if (conexionBD.VerificarConexion())
            {
                // Si está conectada, mostrar en verde
                lblEstadoConexion.Text = "✓ Base de datos conectada";
                lblEstadoConexion.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                // Si no está conectada, mostrar en rojo
                lblEstadoConexion.Text = "✗ Base de datos desconectada";
                lblEstadoConexion.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento del CheckBox para mostrar/ocultar contraseña
        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrar.Checked)
            {
                // Si está marcado, mostrar la contraseña
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                // Si no está marcado, ocultarla con asteriscos
                txtPassword.PasswordChar = '*';
            }
        }

        // Evento del botón Ingresar
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            // Validar que no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, completa todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar contra la base de datos
            if (ValidarCredenciales(usuario, password))
            {
                // Si es correcto, obtener los datos del usuario
                DataTable datosUsuario = ObtenerDatosUsuario(usuario);

                if (datosUsuario.Rows.Count > 0)
                {
                    // Obtener información del usuario
                    string nombreUsuario = datosUsuario.Rows[0]["Nombre"].ToString();
                    string apellidoUsuario = datosUsuario.Rows[0]["Apellido"].ToString();

                    // Abrir el formulario de bienvenida
                    FormBienvenida formBienvenida = new FormBienvenida(nombreUsuario, apellidoUsuario);
                    formBienvenida.ShowDialog();

                    // Limpiar los campos
                    txtUsuario.Text = "";
                    txtPassword.Text = "";
                    intentosFallidos = 0;
                }
            }
            else
            {
                // Contar los intentos fallidos
                intentosFallidos++;
                int intentosRestantes = maximoIntentos - intentosFallidos;

                // Si todavía hay intentos
                if (intentosRestantes > 0)
                {
                    MessageBox.Show($"Usuario o contraseña incorrectos.\nIntentos restantes: {intentosRestantes}", 
                        "Error de login", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Limpiar solo la contraseña
                    txtPassword.Text = "";
                }
                else
                {
                    // Si se acabaron los intentos
                    MessageBox.Show("Cantidad máxima de intentos superada.\nLa aplicación se cerrará.", 
                        "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    // Cerrar la aplicación
                    Application.Exit();
                }
            }
        }

        // Método para validar las credenciales contra la base de datos
        private bool ValidarCredenciales(string usuario, string password)
        {
            try
            {
                // Abrir conexión
                conexionBD.AbrirConexion();

                // Crear la consulta para Access (sin TRIM)
                string consulta = "SELECT * FROM Usuario WHERE Nombre = @usuario AND Contraseña = @password";

                OleDbCommand comando = new OleDbCommand(consulta, conexionBD.ObtenerConexion());

                // Agregar los parámetros para evitar inyección 
                comando.Parameters.AddWithValue("@usuario", usuario.Trim());
                comando.Parameters.AddWithValue("@password", password.Trim());

                // DEBUG: Mostrar qué se está buscando
                System.Diagnostics.Debug.WriteLine($"Buscando usuario: '{usuario}' con contraseña: '{password}'");

                // Ejecutar la consulta
                OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
                DataTable resultado = new DataTable();
                adaptador.Fill(resultado);

                // DEBUG: Mostrar cantidad de filas encontradas
                System.Diagnostics.Debug.WriteLine($"Filas encontradas: {resultado.Rows.Count}");

                if (resultado.Rows.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine($"Usuario encontrado: {resultado.Rows[0]["Nombre"]}");
                }

                // Si encontró un registro, devolver true
                bool esValido = resultado.Rows.Count > 0;

                // Cerrar conexión después de obtener los datos
                conexionBD.CerrarConexion();

                return esValido;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar credenciales: " + ex.Message);
                System.Diagnostics.Debug.WriteLine($"Excepción: {ex.Message}");
                return false;
            }
        }

        // Método para obtener los datos del usuario
        private DataTable ObtenerDatosUsuario(string usuario)
        {
            try
            {
                // Abrir conexión
                conexionBD.AbrirConexion();

                // Consulta para obtener los datos
                string consulta = "SELECT Nombre, Apellido FROM Usuario WHERE Nombre = @usuario";

                OleDbCommand comando = new OleDbCommand(consulta, conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@usuario", usuario);

                OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
                DataTable resultado = new DataTable();
                adaptador.Fill(resultado);

                // Cerrar conexión después de obtener los datos
                conexionBD.CerrarConexion();

                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos del usuario: " + ex.Message);
                return new DataTable();
            }
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void lblEstadoConexion_Click(object sender, EventArgs e)
        {

        }
    }
}
