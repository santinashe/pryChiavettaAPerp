using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    // Clase para manejar la conexión a la base de datos Access
    public class ConexionBD
    {
        // Cadena de conexión a Access - apunta a la carpeta base-dato
        private string cadenaConexion;

        private string ObtenerCadenaConexion()
        {
            string rutaBaseDatos = Path.Combine(Application.StartupPath, "Base-Datos", "BASEDATOSPERF1.accdb");

            // Si no existe en la ruta de ejecución, intentar en la carpeta del proyecto
            if (!File.Exists(rutaBaseDatos))
            {
                rutaBaseDatos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Base-Datos", "BASEDATOSPERF1.accdb");
            }

            return $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={rutaBaseDatos};";
        }

        // Variable para almacenar la conexión
        private OleDbConnection conexion;

        public OleDbConnection Conexion
        {
            get { return conexion; }
        }

        // Constructor - inicializa la conexión
        public ConexionBD()
        {
            cadenaConexion = ObtenerCadenaConexion();
            conexion = new OleDbConnection(cadenaConexion);
        }

        // Método para abrir la conexión a la base de datos
        public bool AbrirConexion()
        {
            try
            {
                // Si la conexión está cerrada, la abrimos
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la conexión: " + ex.Message);
                return false;
            }
        }

        // Método para cerrar la conexión
        public bool CerrarConexion()
        {
            try
            {
                // Si la conexión está abierta, la cerramos
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
                return false;
            }
        }

        // Método para verificar si la conexión está activa
        public bool VerificarConexion()
        {
            try
            {
                // Intentamos abrir la conexión
                AbrirConexion();

                // Verificamos el estado
                bool estaConectada = conexion.State == System.Data.ConnectionState.Open;

                // Cerramos la conexión
                CerrarConexion();

                return estaConectada;
            }
            catch
            {
                return false;
            }
        }

        // Método para obtener la conexión (para usarla en consultas)
        public OleDbConnection ObtenerConexion()
        {
            return conexion;
        }
    }
}
