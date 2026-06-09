using System;
using System.IO;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public static class Config
    {
        public static string ObtenerRutaBD()
        {
            DirectoryInfo carpeta = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (carpeta != null)
            {
                string rutaPedida = Path.Combine(carpeta.FullName, "Base de Datos", "BASEDATOSPERF1.accdb");
                if (File.Exists(rutaPedida))
                {
                    return rutaPedida;
                }

                string rutaExistente = Path.Combine(carpeta.FullName, "Base-Datos", "BASEDATOSPERF1.accdb");
                if (File.Exists(rutaExistente))
                {
                    return rutaExistente;
                }

                carpeta = carpeta.Parent;
            }

            MessageBox.Show("No se encontró la base de datos BASEDATOSPERF1.accdb. Verificá que esté dentro de la carpeta Base de Datos.",
                "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return "";
        }

        public static string CadenaConexion
        {
            get
            {
                return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ObtenerRutaBD() + ";";
            }
        }

        public const string TABLA_USUARIO = "Usuario";
        public const string TABLA_REDES = "Redes";
        public const string TABLA_PERFIL = "Perfil";
        public const string TABLA_RELACION_USUARIO_PERFIL = "RelacionUsuarioPerfil";
        public const string TABLA_AUDITORIA = "Auditoria";
    }
}
