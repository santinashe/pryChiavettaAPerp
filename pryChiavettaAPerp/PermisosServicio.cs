using System;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public static class PermisosServicio
    {
        public const string RolAdministrador = "Administrador";
        public const string RolSupervisor = "Supervisor";
        public const string RolOperador = "Operador";

        public static string NormalizarRol(string rol)
        {
            if (string.IsNullOrWhiteSpace(rol))
            {
                return RolOperador;
            }

            string valor = rol.Trim().ToLowerInvariant();

            if (valor == "admin" || valor == "administrador")
            {
                return RolAdministrador;
            }

            if (valor == "rrhh" || valor == "supervisor")
            {
                return RolSupervisor;
            }

            if (valor == "logistica" || valor == "logística" || valor == "operador")
            {
                return RolOperador;
            }

            return RolOperador;
        }

        public static bool PuedeGestionarUsuarios()
        {
            string rol = NormalizarRol(SesionActual.Rol);
            return rol == RolAdministrador || rol == RolSupervisor;
        }

        public static bool PuedeVerAuditoria()
        {
            return NormalizarRol(SesionActual.Rol) == RolAdministrador;
        }

        public static bool PuedeGestionarPersonal()
        {
            return NormalizarRol(SesionActual.Rol) == RolAdministrador ||
                   NormalizarRol(SesionActual.Rol) == RolSupervisor ||
                   NormalizarRol(SesionActual.Rol) == RolOperador;
        }

        public static void AplicarPermiso(Button boton, bool permitido)
        {
            if (boton == null)
            {
                return;
            }

            boton.Enabled = permitido;
            boton.Visible = permitido;
        }

        public static void Exigir(bool permitido, string mensaje)
        {
            if (!permitido)
            {
                throw new UnauthorizedAccessException(mensaje);
            }
        }
    }
}
