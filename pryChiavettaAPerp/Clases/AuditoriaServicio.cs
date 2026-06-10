using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace pryChiavettaAPerp
{
    public static class AuditoriaServicio
    {
        public static void AsegurarTablaAuditoria()
        {
            using (OleDbConnection conexion = new OleDbConnection(Config.CadenaConexion))
            {
                conexion.Open();

                if (TablaExiste(conexion, "Auditoria"))
                {
                    AsegurarColumna(conexion, "Auditoria", "Rol", "TEXT(50)");
                    AsegurarColumna(conexion, "Auditoria", "Detalle", "LONGTEXT");
                    return;
                }

                string sql = @"CREATE TABLE [Auditoria] (
                    [IdAuditoria] AUTOINCREMENT PRIMARY KEY,
                    [FechaHora] DATETIME,
                    [Usuario] TEXT(150),
                    [Rol] TEXT(50),
                    [Formulario] TEXT(100),
                    [Movimiento] TEXT(80),
                    [Detalle] LONGTEXT
                )";

                using (OleDbCommand comando = new OleDbCommand(sql, conexion))
                {
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void RegistrarAuditoria(string formulario, string movimiento)
        {
            RegistrarAuditoria(formulario, movimiento, "");
        }

        public static void RegistrarAuditoria(string formulario, string movimiento, string detalle)
        {
            try
            {
                AsegurarTablaAuditoria();

                using (OleDbConnection conexion = new OleDbConnection(Config.CadenaConexion))
                {
                    conexion.Open();

                    string sql = @"INSERT INTO [Auditoria]
                        ([FechaHora], [Usuario], [Rol], [Formulario], [Movimiento], [Detalle])
                        VALUES (?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand comando = new OleDbCommand(sql, conexion))
                    {
                        comando.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;
                        comando.Parameters.Add("?", OleDbType.VarWChar).Value = SesionActual.UsuarioAuditoria;
                        comando.Parameters.Add("?", OleDbType.VarWChar).Value = PermisosServicio.NormalizarRol(SesionActual.Rol);
                        comando.Parameters.Add("?", OleDbType.VarWChar).Value = formulario ?? "";
                        comando.Parameters.Add("?", OleDbType.VarWChar).Value = movimiento ?? "";
                        comando.Parameters.Add("?", OleDbType.LongVarWChar).Value = detalle ?? "";
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // La auditoría nunca debe bloquear la operación principal.
            }
        }

        public static DataTable ObtenerAuditoria()
        {
            AsegurarTablaAuditoria();
            return OperacionesBD.ObtenerDatos("SELECT * FROM [Auditoria] ORDER BY [FechaHora] DESC");
        }

        public static bool TablaExiste(OleDbConnection conexion, string tabla)
        {
            DataTable esquema = conexion.GetOleDbSchemaTable(
                OleDbSchemaGuid.Tables,
                new object[] { null, null, tabla, "TABLE" });

            return esquema != null && esquema.Rows.Count > 0;
        }

        public static bool ColumnaExiste(OleDbConnection conexion, string tabla, string columna)
        {
            DataTable esquema = conexion.GetOleDbSchemaTable(
                OleDbSchemaGuid.Columns,
                new object[] { null, null, tabla, columna });

            return esquema != null && esquema.Rows.Count > 0;
        }

        private static void AsegurarColumna(OleDbConnection conexion, string tabla, string columna, string tipo)
        {
            if (ColumnaExiste(conexion, tabla, columna))
            {
                return;
            }

            using (OleDbCommand comando = new OleDbCommand(
                "ALTER TABLE [" + tabla + "] ADD COLUMN [" + columna + "] " + tipo,
                conexion))
            {
                comando.ExecuteNonQuery();
            }
        }
    }
}
