using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    /// <summary>
    /// Clase auxiliar para gestionar la geolocalización y Google Maps.
    /// Contiene ejemplos de cómo obtener y usar coordenadas.
    /// </summary>
    public class GeolocalizacionHelper
    {
        /// <summary>
        /// Abre Google Maps en el navegador con coordenadas especificadas.
        /// </summary>
        /// <param name="latitud">Latitud (ej: -31.4135)</param>
        /// <param name="longitud">Longitud (ej: -64.1811)</param>
        /// <param name="zoom">Nivel de zoom (recomendado: 15)</param>
        public static void AbrirGoogleMaps(string latitud, string longitud, int zoom = 15)
        {
            try
            {
                // Construir URL de Google Maps
                string url = $"https://www.google.com/maps/@{latitud},{longitud},{zoom}z";
                
                // Abrir en navegador predeterminado
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir Google Maps: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre Google Maps en modo búsqueda (para una dirección de texto).
        /// Útil si tienes una dirección pero no coordenadas exactas.
        /// </summary>
        /// <param name="direccion">Dirección a buscar (ej: "Córdoba, Argentina")</param>
        public static void AbrirGoogleMapsPorDireccion(string direccion)
        {
            try
            {
                // Reemplazar espacios por + para URL encoding
                string direccionCodificada = direccion.Replace(" ", "+");
                string url = $"https://www.google.com/maps/search/{direccionCodificada}";
                
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir búsqueda en Google Maps: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ejemplos de coordenadas de ciudades importantes en Argentina.
        /// Útil para testing sin conexión a GPS real.
        /// </summary>
        public static class CiudadesArgentina
        {
            // Buenos Aires
            public const string BUENOS_AIRES_LAT = "-34.6037";
            public const string BUENOS_AIRES_LON = "-58.3816";

            // Córdoba
            public const string CORDOBA_LAT = "-31.4135";
            public const string CORDOBA_LON = "-64.1811";

            // Mendoza
            public const string MENDOZA_LAT = "-32.8895";
            public const string MENDOZA_LON = "-68.8458";

            // Rosario
            public const string ROSARIO_LAT = "-32.9468";
            public const string ROSARIO_LON = "-60.6393";

            // La Plata
            public const string LA_PLATA_LAT = "-34.9205";
            public const string LA_PLATA_LON = "-57.9549";

            // Mar del Plata
            public const string MAR_DEL_PLATA_LAT = "-38.0055";
            public const string MAR_DEL_PLATA_LON = "-57.5527";

            // Salta
            public const string SALTA_LAT = "-24.7859";
            public const string SALTA_LON = "-65.4064";

            // Tucumán
            public const string TUCUMAN_LAT = "-26.8083";
            public const string TUCUMAN_LON = "-65.2158";

            // Bahía Blanca
            public const string BAHIA_BLANCA_LAT = "-38.7196";
            public const string BAHIA_BLANCA_LON = "-62.2723";

            // Jujuy
            public const string JUJUY_LAT = "-23.5885";
            public const string JUJUY_LON = "-65.2992";
        }

        /// <summary>
        /// Simula obtener coordenadas según la provincia seleccionada.
        /// En una app real, usarías GPS real del dispositivo.
        /// </summary>
        /// <param name="provincia">Nombre de la provincia</param>
        /// <returns>Tupla con (latitud, longitud)</returns>
        public static (string latitud, string longitud) ObtenerCoordenadas(string provincia)
        {
            // Si la provincia es nula o está vacía, usar Córdoba por defecto
            if (string.IsNullOrWhiteSpace(provincia))
            {
                return (CiudadesArgentina.CORDOBA_LAT, CiudadesArgentina.CORDOBA_LON);
            }

            // Convertir a minúsculas para comparación
            string prov = provincia.ToLower();

            // Usar IF-ELSE en lugar de switch expression (compatible con C# 7.3)
            if (prov == "buenos aires")
                return (CiudadesArgentina.BUENOS_AIRES_LAT, CiudadesArgentina.BUENOS_AIRES_LON);
            else if (prov == "córdoba")
                return (CiudadesArgentina.CORDOBA_LAT, CiudadesArgentina.CORDOBA_LON);
            else if (prov == "mendoza")
                return (CiudadesArgentina.MENDOZA_LAT, CiudadesArgentina.MENDOZA_LON);
            else if (prov == "santa fe")
                return (CiudadesArgentina.ROSARIO_LAT, CiudadesArgentina.ROSARIO_LON);
            else if (prov == "la pampa")
                return (CiudadesArgentina.LA_PLATA_LAT, CiudadesArgentina.LA_PLATA_LON);
            else if (prov == "río negro")
                return (CiudadesArgentina.MAR_DEL_PLATA_LAT, CiudadesArgentina.MAR_DEL_PLATA_LON);
            else if (prov == "salta")
                return (CiudadesArgentina.SALTA_LAT, CiudadesArgentina.SALTA_LON);
            else if (prov == "tucumán")
                return (CiudadesArgentina.TUCUMAN_LAT, CiudadesArgentina.TUCUMAN_LON);
            else if (prov == "jujuy")
                return (CiudadesArgentina.JUJUY_LAT, CiudadesArgentina.JUJUY_LON);
            else if (prov == "chubut")
                return (CiudadesArgentina.BAHIA_BLANCA_LAT, CiudadesArgentina.BAHIA_BLANCA_LON);
            else
                // Por defecto, retornar Córdoba
                return (CiudadesArgentina.CORDOBA_LAT, CiudadesArgentina.CORDOBA_LON);
        }

        /// <summary>
        /// Valida si las coordenadas están en rango válido.
        /// Latitud: -90 a 90
        /// Longitud: -180 a 180
        /// </summary>
        public static bool ValidarCoordenadas(string latitud, string longitud)
        {
            if (!double.TryParse(latitud, out double lat) || !double.TryParse(longitud, out double lon))
                return false;

            return lat >= -90 && lat <= 90 && lon >= -180 && lon <= 180;
        }

        /// <summary>
        /// Obtiene la URL de una imagen estática de Google Maps.
        /// Útil para mostrar un preview sin abrir el navegador.
        /// </summary>
        /// <param name="latitud">Latitud</param>
        /// <param name="longitud">Longitud</param>
        /// <param name="zoom">Zoom level (default 15)</param>
        /// <param name="ancho">Ancho de la imagen en píxeles</param>
        /// <param name="alto">Alto de la imagen en píxeles</param>
        /// <returns>URL de Google Static Maps API</returns>
        public static string ObtenerURLImagenMapa(string latitud, string longitud, 
            int zoom = 15, int ancho = 400, int alto = 300)
        {
            // Nota: Necesitas una API Key de Google para usar esto
            // Por ahora, retorna URL genérica
            return $"https://maps.googleapis.com/maps/api/staticmap?center={latitud},{longitud}&zoom={zoom}&size={ancho}x{alto}&key=TU_API_KEY_AQUI";
        }
    }
}
