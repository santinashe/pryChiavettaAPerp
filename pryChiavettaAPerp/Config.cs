using System;
using System.IO;

namespace pryChiavettaAPerp
{
    /// <summary>
    /// Clase estática para gestionar la configuración global de la aplicación.
    /// Aquí almacenaremos constantes y rutas que se usan en toda la app.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Obtiene la ruta dinámica de la base de datos.
        /// Esto permite que funcione sin importar dónde esté la carpeta del proyecto.
        /// 
        /// Explicación:
        /// - AppDomain.CurrentDomain.BaseDirectory = carpeta donde se ejecuta la app
        /// - "..", "..", "Base-Datos", "..." = navega hacia atrás 2 carpetas y busca la BD
        /// </summary>
        public static string ObtenerRutaBD()
        {
            // Carpeta donde se ejecuta la aplicación (Debug o Release)
            string directorioActual = AppDomain.CurrentDomain.BaseDirectory;

            // Navegar hasta encontrar la carpeta Base-Datos y el archivo accdb
            // Estructura: pryChiavettaAPerp -> Base-Datos -> BASEDATOSPERF1.accdb
            string rutaBD = Path.Combine(directorioActual, "..", "..", "Base-Datos", "BASEDATOSPERF1.accdb");

            return Path.GetFullPath(rutaBD);
        }

        /// <summary>
        /// Cadena de conexión a la base de datos Access.
        /// Usa OLEDB 12.0 (compatible con Office 2007 en adelante).
        /// </summary>
        public static string CadenaConexion
        {
            get
            {
                return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ObtenerRutaBD()};";
            }
        }

        // Constantes para los nombres de las tablas en la BD
        public const string TABLA_USUARIO = "Usuario";
        public const string TABLA_REDES = "Redes";
        public const string TABLA_PERFIL = "Perfil";
        public const string TABLA_RELACION_USUARIO_PERFIL = "RelacionUsuarioPerfil";
        public const string TABLA_AUDITORIA = "Auditoria";
    }
}
