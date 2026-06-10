using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public class ConexionBD
    {
        private string cadenaConexion;
        private OleDbConnection conexion;

        public OleDbConnection Conexion
        {
            get { return conexion; }
        }

        public ConexionBD()
        {
            cadenaConexion = Config.CadenaConexion;
            conexion = new OleDbConnection(cadenaConexion);
        }

        public bool AbrirConexion()
        {
            try
            {
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

        public bool CerrarConexion()
        {
            try
            {
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

        public bool VerificarConexion()
        {
            try
            {
                AbrirConexion();
                bool estaConectada = conexion.State == System.Data.ConnectionState.Open;
                CerrarConexion();
                return estaConectada;
            }
            catch
            {
                return false;
            }
        }

        public OleDbConnection ObtenerConexion()
        {
            return conexion;
        }
    }
}
