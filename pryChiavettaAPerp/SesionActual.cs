using System;

namespace pryChiavettaAPerp
{
    public static class SesionActual
    {
        public static int IdUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static string Mail { get; set; }
        public static string Rol { get; set; }
        public static DateTime FechaIngreso { get; set; }

        public static string UsuarioAuditoria
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Mail))
                {
                    return Mail;
                }

                if (!string.IsNullOrWhiteSpace(Nombre))
                {
                    return Nombre;
                }

                return "Sistema";
            }
        }

        public static void CerrarSesion()
        {
            IdUsuario = 0;
            Nombre = "";
            Apellido = "";
            Mail = "";
            Rol = "";
            FechaIngreso = DateTime.MinValue;
        }
    }
}
