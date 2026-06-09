using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace pryChiavettaAPerp
{
    public static class UsuarioServicio
    {
        public static void AsegurarRolesBase()
        {
            AsegurarPerfil(PermisosServicio.RolAdministrador);
            AsegurarPerfil(PermisosServicio.RolSupervisor);
            AsegurarPerfil(PermisosServicio.RolOperador);
        }

        public static DataTable ObtenerUsuarios()
        {
            string sql = @"SELECT u.[IdUsuario], u.[Nombre], u.[Apellido], u.[Dni], u.[Mail], u.[Contraseña],
                    p.[Nombre] AS [Perfil]
                FROM ([Usuario] u
                LEFT JOIN [RelacionUsuarioPerfil] r ON CStr(u.[IdUsuario]) = r.[IdUsuario])
                LEFT JOIN [Perfil] p ON CStr(p.[IdPerfil]) = r.[IdPerfil]
                ORDER BY u.[Nombre], u.[Apellido]";

            return OperacionesBD.ObtenerDatos(sql);
        }

        public static DataTable ObtenerUsuarioPorNombre(string nombre)
        {
            string sql = @"SELECT TOP 1 u.[IdUsuario], u.[Nombre], u.[Apellido], u.[Dni], u.[Mail], u.[Contraseña],
                    p.[Nombre] AS [Perfil]
                FROM ([Usuario] u
                LEFT JOIN [RelacionUsuarioPerfil] r ON CStr(u.[IdUsuario]) = r.[IdUsuario])
                LEFT JOIN [Perfil] p ON CStr(p.[IdPerfil]) = r.[IdPerfil]
                WHERE u.[Nombre] = ?";

            return OperacionesBD.ObtenerDatos(sql, new OleDbParameter[]
            {
                new OleDbParameter("?", nombre)
            });
        }

        public static bool ExisteDuplicado(string nombre, string dni, string mail, int idExcluir)
        {
            string sql = @"SELECT COUNT(*) AS Total
                FROM [Usuario]
                WHERE ([Nombre] = ? OR [Dni] = ? OR [Mail] = ?) AND [IdUsuario] <> ?";

            DataTable tabla = OperacionesBD.ObtenerDatos(sql, new OleDbParameter[]
            {
                new OleDbParameter("?", nombre),
                new OleDbParameter("?", dni),
                new OleDbParameter("?", mail),
                new OleDbParameter("?", idExcluir)
            });

            return tabla.Rows.Count > 0 && Convert.ToInt32(tabla.Rows[0]["Total"]) > 0;
        }

        public static int Alta(string nombre, string apellido, string dni, string mail, string contrasenia, string rol)
        {
            ValidarCampos(nombre, apellido, dni, mail, contrasenia);

            if (ExisteDuplicado(nombre, dni, mail, 0))
            {
                throw new InvalidOperationException("Ya existe un usuario con el mismo nombre, DNI o mail.");
            }

            int idUsuario = ObtenerSiguienteId("Usuario", "IdUsuario");

            string sql = @"INSERT INTO [Usuario]
                ([IdUsuario], [Nombre], [Apellido], [Dni], [Mail], [Contraseña])
                VALUES (?, ?, ?, ?, ?, ?)";

            OperacionesBD.EjecutarComando(sql, new OleDbParameter[]
            {
                new OleDbParameter("?", idUsuario),
                new OleDbParameter("?", nombre.Trim()),
                new OleDbParameter("?", apellido.Trim()),
                new OleDbParameter("?", dni.Trim()),
                new OleDbParameter("?", mail.Trim()),
                new OleDbParameter("?", contrasenia.Trim())
            });

            AsignarRol(idUsuario, rol);
            AuditoriaServicio.RegistrarAuditoria("frmGestionUsuarios", "Alta", "Usuario Id " + idUsuario);
            return idUsuario;
        }

        public static void Modificar(int idUsuario, string nombre, string apellido, string dni, string mail, string contrasenia, string rol)
        {
            if (idUsuario <= 0)
            {
                throw new InvalidOperationException("Seleccione un usuario para modificar.");
            }

            ValidarCampos(nombre, apellido, dni, mail, contrasenia);

            if (ExisteDuplicado(nombre, dni, mail, idUsuario))
            {
                throw new InvalidOperationException("Ya existe otro usuario con el mismo nombre, DNI o mail.");
            }

            string sql = @"UPDATE [Usuario]
                SET [Nombre] = ?, [Apellido] = ?, [Dni] = ?, [Mail] = ?, [Contraseña] = ?
                WHERE [IdUsuario] = ?";

            OperacionesBD.EjecutarComando(sql, new OleDbParameter[]
            {
                new OleDbParameter("?", nombre.Trim()),
                new OleDbParameter("?", apellido.Trim()),
                new OleDbParameter("?", dni.Trim()),
                new OleDbParameter("?", mail.Trim()),
                new OleDbParameter("?", contrasenia.Trim()),
                new OleDbParameter("?", idUsuario)
            });

            AsignarRol(idUsuario, rol);
            AuditoriaServicio.RegistrarAuditoria("frmGestionUsuarios", "Modificación", "Usuario Id " + idUsuario);
        }

        public static void Baja(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                throw new InvalidOperationException("Seleccione un usuario para eliminar.");
            }

            OperacionesBD.EjecutarComando("DELETE FROM [RelacionUsuarioPerfil] WHERE [IdUsuario] = ?", new OleDbParameter[]
            {
                new OleDbParameter("?", idUsuario.ToString())
            });

            OperacionesBD.EjecutarComando("DELETE FROM [Usuario] WHERE [IdUsuario] = ?", new OleDbParameter[]
            {
                new OleDbParameter("?", idUsuario)
            });

            AuditoriaServicio.RegistrarAuditoria("frmGestionUsuarios", "Baja", "Usuario Id " + idUsuario);
        }

        public static void AsignarRol(int idUsuario, string rol)
        {
            string rolNormalizado = PermisosServicio.NormalizarRol(rol);
            int idPerfil = AsegurarPerfil(rolNormalizado);

            OperacionesBD.EjecutarComando("DELETE FROM [RelacionUsuarioPerfil] WHERE [IdUsuario] = ?", new OleDbParameter[]
            {
                new OleDbParameter("?", idUsuario.ToString())
            });

            int idRelacion = ObtenerSiguienteId("RelacionUsuarioPerfil", "Id");
            OperacionesBD.EjecutarComando(
                "INSERT INTO [RelacionUsuarioPerfil] ([Id], [IdUsuario], [IdPerfil]) VALUES (?, ?, ?)",
                new OleDbParameter[]
                {
                    new OleDbParameter("?", idRelacion),
                    new OleDbParameter("?", idUsuario.ToString()),
                    new OleDbParameter("?", idPerfil.ToString())
                });
        }

        public static int AsegurarPerfil(string nombrePerfil)
        {
            string rol = PermisosServicio.NormalizarRol(nombrePerfil);
            DataTable tabla = OperacionesBD.ObtenerDatos("SELECT TOP 1 [IdPerfil] FROM [Perfil] WHERE [Nombre] = ?", new OleDbParameter[]
            {
                new OleDbParameter("?", rol)
            });

            if (tabla.Rows.Count > 0)
            {
                return Convert.ToInt32(tabla.Rows[0]["IdPerfil"]);
            }

            int id = ObtenerSiguienteId("Perfil", "IdPerfil");
            OperacionesBD.EjecutarComando("INSERT INTO [Perfil] ([IdPerfil], [Nombre]) VALUES (?, ?)", new OleDbParameter[]
            {
                new OleDbParameter("?", id),
                new OleDbParameter("?", rol)
            });

            return id;
        }

        public static int ObtenerSiguienteId(string tabla, string campo)
        {
            DataTable datos = OperacionesBD.ObtenerDatos("SELECT MAX([" + campo + "]) AS UltimoId FROM [" + tabla + "]");

            if (datos.Rows.Count == 0 || datos.Rows[0]["UltimoId"] == DBNull.Value)
            {
                return 1;
            }

            return Convert.ToInt32(datos.Rows[0]["UltimoId"]) + 1;
        }

        private static void ValidarCampos(string nombre, string apellido, string dni, string mail, string contrasenia)
        {
            List<string> faltantes = new List<string>();

            if (string.IsNullOrWhiteSpace(nombre)) faltantes.Add("Nombre");
            if (string.IsNullOrWhiteSpace(apellido)) faltantes.Add("Apellido");
            if (string.IsNullOrWhiteSpace(dni)) faltantes.Add("DNI");
            if (string.IsNullOrWhiteSpace(mail)) faltantes.Add("Mail");
            if (string.IsNullOrWhiteSpace(contrasenia)) faltantes.Add("Contraseña");

            if (faltantes.Count > 0)
            {
                throw new InvalidOperationException("Campos obligatorios incompletos: " + string.Join(", ", faltantes));
            }
        }
    }
}
