using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public partial class Form1 : Form
    {
        // Variable para manejar la conexión a la base de datos
        private ConexionBD conexionBD;

        // Contador de intentos fallidos
        private int intentosFallidos = 0;
        private int maximoIntentos = 3;

        public Form1()
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
                lblEstadoConexion.Text = "✓ Base de datos conectada";
                lblEstadoConexion.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblEstadoConexion.Text = "✗ Base de datos desconectada";
                lblEstadoConexion.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento del CheckBox para mostrar/ocultar contraseña
        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrar.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        // Evento del botón Ingresar - MODIFICADO PARA BUSCAR POR MAIL
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados limpiando espacios vacíos
            string mailIngresado = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validar que no estén vacíos
            if (string.IsNullOrEmpty(mailIngresado) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, completa todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Abrir la conexión
                conexionBD.AbrirConexion();

                // 2. Consulta usando '?' (así se manejan los parámetros de forma segura en OleDb/Access)
                // ATENCIÓN: Si en tu Access la columna se llama 'Contrasenia', cambialo acá abajo.
                string consulta = "SELECT [Nombre], [Apellido], [Contraseña] FROM [Usuario] WHERE [Mail] = ?";

                OleDbCommand comando = new OleDbCommand(consulta, conexionBD.ObtenerConexion());

                // OleDb asigna los parámetros por ORDEN, el nombre acá no importa tanto como el orden en que los agregás
                comando.Parameters.AddWithValue("?", mailIngresado);

                OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                // Cerramos la conexión rápido
                conexionBD.CerrarConexion();

                // 3. Validar si el Mail realmente existía en la base de datos
                if (tabla.Rows.Count > 0)
                {
                    string nombreBD = tabla.Rows[0]["Nombre"].ToString().Trim();
                    string apellidoBD = tabla.Rows[0]["Apellido"].ToString().Trim();
                    string contrasenaBD = tabla.Rows[0]["Contraseña"].ToString().Trim(); // Cambiar por "Contrasenia" si hace falta

                    // 4. Comparación segura (ignora si es mayúscula o minúscula)
                    if (string.Equals(contrasenaBD, password, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Ingreso correcto. Bienvenido al sistema, " + nombreBD, "Acceso permitido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Abrir el formulario de bienvenida pasando nombre y apellido
                        FormBienvenida formBienvenida = new FormBienvenida(nombreBD, apellidoBD);
                        formBienvenida.ShowDialog();

                        // Limpiar campos y resetear intentos
                        txtUsuario.Text = "";
                        txtPassword.Text = "";
                        intentosFallidos = 0;
                        return; // Corta la ejecución porque todo salió bien
                    }
                }

                // 5. Si no encontró el mail o la contraseña no coincidió, va a los intentos fallidos
                ProcesarIntentoFallido();
            }
            catch (Exception ex)
            {
                conexionBD.CerrarConexion();
                MessageBox.Show("Error al procesar las credenciales: " + ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        // Método auxiliar para manejar el contador de intentos
        private void ProcesarIntentoFallido()
        {
            intentosFallidos++;
            int intentosRestantes = maximoIntentos - intentosFallidos;

            if (intentosRestantes > 0)
            {
                MessageBox.Show($"Usuario o contraseña incorrectos.\nIntentos restantes: {intentosRestantes}",
                    "Error de login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
            }
            else
            {
                MessageBox.Show("Cantidad máxima de intentos superada.\nLa aplicación se cerrará.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
        }
    }
}