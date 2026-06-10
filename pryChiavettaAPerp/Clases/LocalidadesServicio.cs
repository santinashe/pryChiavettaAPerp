using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public static class LocalidadesServicio
    {
        private const string MensajeBaseNoEncontrada = "No se encontró la base de datos de localidades. Verificá que el archivo esté en la carpeta Base de Datos.";

        public static List<string> ObtenerProvincias()
        {
            List<string> provincias = new List<string>();
            string ruta = ObtenerRutaBase();

            if (ruta == "")
            {
                MessageBox.Show(MensajeBaseNoEncontrada, "Localidades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return provincias;
            }

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(CrearCadenaConexion(ruta)))
                using (OleDbCommand comando = new OleDbCommand("SELECT DISTINCT Provincia FROM Localidades WHERE Provincia IS NOT NULL ORDER BY Provincia", conexion))
                {
                    conexion.Open();

                    using (OleDbDataReader lector = comando.ExecuteReader())
                    {
                        while (lector != null && lector.Read())
                        {
                            string provincia = lector["Provincia"].ToString().Trim();
                            if (provincia != "" && !provincias.Contains(provincia))
                            {
                                provincias.Add(provincia);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error inesperado al cargar las provincias. Revisá los datos e intentá nuevamente.", "Localidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return provincias;
        }

        public static List<string> ObtenerLocalidades(string provincia)
        {
            List<string> localidades = new List<string>();

            if (string.IsNullOrWhiteSpace(provincia))
            {
                return localidades;
            }

            string ruta = ObtenerRutaBase();

            if (ruta == "")
            {
                MessageBox.Show(MensajeBaseNoEncontrada, "Localidades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return localidades;
            }

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(CrearCadenaConexion(ruta)))
                using (OleDbCommand comando = new OleDbCommand("SELECT Nombre FROM Localidades WHERE Provincia = ? ORDER BY Nombre", conexion))
                {
                    comando.Parameters.AddWithValue("?", provincia);
                    conexion.Open();

                    using (OleDbDataReader lector = comando.ExecuteReader())
                    {
                        while (lector != null && lector.Read())
                        {
                            string localidad = lector["Nombre"].ToString().Trim();
                            if (localidad != "" && !localidades.Contains(localidad))
                            {
                                localidades.Add(localidad);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error inesperado al cargar las localidades. Revisá los datos e intentá nuevamente.", "Localidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return localidades;
        }

        private static string CrearCadenaConexion(string ruta)
        {
            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta + ";Persist Security Info=False;";
        }

        private static string ObtenerRutaBase()
        {
            DirectoryInfo carpeta = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (carpeta != null)
            {
                string rutaPedida = Path.Combine(carpeta.FullName, "Base de Datos", "LocalidadBD(2).accdb");
                if (File.Exists(rutaPedida))
                {
                    return rutaPedida;
                }

                string rutaExistente = Path.Combine(carpeta.FullName, "Base-Datos", "LocalidadBD.accdb");
                if (File.Exists(rutaExistente))
                {
                    return rutaExistente;
                }

                carpeta = carpeta.Parent;
            }

            return "";
        }
    }
}
