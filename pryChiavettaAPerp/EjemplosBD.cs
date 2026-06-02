using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    /// <summary>
    /// Clase con ejemplos de uso avanzado de la BD.
    /// Útil para implementar funcionalidades adicionales como:
    /// - Búsqueda de usuarios
    /// - Actualización de datos
    /// - Eliminación de registros
    /// - Reportes
    /// </summary>
    public class EjemplosBD
    {
        // ============================================================================
        //                  EJEMPLOS 1: BÚSQUEDA DE USUARIOS
        // ============================================================================

        /// <summary>
        /// Busca un usuario por su DNI.
        /// Retorna los datos en un DataTable para trabajar con ellos.
        /// </summary>
        public static DataTable BuscarUsuarioPorDNI(string dni)
        {
            try
            {
                string consulta = "SELECT * FROM Usuario WHERE DNI = @dni";
                OleDbParameter[] parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@dni", dni)
                };

                DataTable resultado = OperacionesBD.ObtenerDatos(consulta, parametros);
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar usuario: {ex.Message}");
                return new DataTable();
            }
        }

        /// <summary>
        /// Busca un usuario por su Mail.
        /// </summary>
        public static DataTable BuscarUsuarioPorMail(string mail)
        {
            try
            {
                string consulta = "SELECT * FROM Usuario WHERE Mail = @mail";
                OleDbParameter[] parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@mail", mail)
                };

                return OperacionesBD.ObtenerDatos(consulta, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar usuario: {ex.Message}");
                return new DataTable();
            }
        }

        /// <summary>
        /// Busca todos los usuarios de una provincia específica.
        /// Útil para filtrar por ubicación.
        /// </summary>
        public static DataTable BuscarUsuariosPorProvincia(string provincia)
        {
            try
            {
                string consulta = "SELECT * FROM Usuario WHERE Provincia = @provincia ORDER BY Nombre";
                OleDbParameter[] parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@provincia", provincia)
                };

                return OperacionesBD.ObtenerDatos(consulta, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar usuarios: {ex.Message}");
                return new DataTable();
            }
        }

        // ============================================================================
        //                  EJEMPLOS 2: ACTUALIZACIÓN DE DATOS
        // ============================================================================

        /// <summary>
        /// Actualiza el estado de un usuario (Activo/Inactivo).
        /// </summary>
        public static bool ActualizarEstadoUsuario(int idUsuario, string nuevoEstado)
        {
            try
            {
                string consulta = @"
                    UPDATE Usuario 
                    SET Estado = @estado, FechaModificacion = NOW()
                    WHERE ID = @id";

                OleDbParameter[] parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@estado", nuevoEstado),
                    new OleDbParameter("@id", idUsuario)
                };

                return OperacionesBD.EjecutarComando(consulta, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar estado: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Actualiza el email de un usuario.
        /// </summary>
        public static bool ActualizarMailUsuario(int idUsuario, string nuevoMail)
        {
            try
            {
                // Validar que el nuevo mail sea único
                DataTable verificacion = BuscarUsuarioPorMail(nuevoMail);
                if (verificacion.Rows.Count > 0)
                {
                    MessageBox.Show("El email ya está registrado.");
                    return false;
                }

                string consulta = @"
                    UPDATE Usuario 
                    SET Mail = @mail, FechaModificacion = NOW()
                    WHERE ID = @id";

                OleDbParameter[] parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@mail", nuevoMail),
                    new OleDbParameter("@id", idUsuario)
                };

                return OperacionesBD.EjecutarComando(consulta, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar email: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Actualiza todos los datos de un usuario.
        /// </summary>
        public static bool ActualizarUsuarioCompleto(
            int idUsuario,
            string nombre,
            string apellido,
            string telefono,
            string provincia,
            string localidad,
            string usuarioRedes)
        {
            try
            {
                string consulta = @"
                    UPDATE Usuario 
                    SET Nombre = @nombre,
                        Apellido = @apellido,
                        Telefono = @telefono,
                        Provincia = @provincia,
                        Localidad = @localidad,
                        UsuarioRedes = @usuarioRedes,
                        FechaModificacion = NOW()
                    WHERE ID = @id";

                OleDbParameter[] parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@nombre", nombre),
                    new OleDbParameter("@apellido", apellido),
                    new OleDbParameter("@telefono", telefono),
                    new OleDbParameter("@provincia", provincia),
                    new OleDbParameter("@localidad", localidad),
                    new OleDbParameter("@usuarioRedes", usuarioRedes),
                    new OleDbParameter("@id", idUsuario)
                };

                return OperacionesBD.EjecutarComando(consulta, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar usuario: {ex.Message}");
                return false;
            }
        }

        // ============================================================================
        //                  EJEMPLOS 3: ELIMINACIÓN DE REGISTROS
        // ============================================================================

        /// <summary>
        /// Elimina una red social específica de un usuario.
        /// </summary>
        public static bool EliminarRedDelUsuario(int idUsuario, string nombreRed)
        {
            try
            {
                string consulta = @"
                    DELETE FROM Redes 
                    WHERE IDUsuario = @idUsuario AND NombreRed = @nombreRed";

                OleDbParameter[] parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", idUsuario),
                    new OleDbParameter("@nombreRed", nombreRed)
                };

                return OperacionesBD.EjecutarComando(consulta, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar red: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina todas las redes de un usuario (sin eliminar al usuario).
        /// </summary>
        public static bool EliminarTodasLasRedesDelUsuario(int idUsuario)
        {
            try
            {
                string consulta = "DELETE FROM Redes WHERE IDUsuario = @idUsuario";
                OleDbParameter[] parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", idUsuario)
                };

                return OperacionesBD.EjecutarComando(consulta, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar redes: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina completamente un usuario y todas sus redes.
        /// CUIDADO: Esta operación es definitiva.
        /// </summary>
        public static bool EliminarUsuarioCompleto(int idUsuario)
        {
            try
            {
                // Primero, eliminar todas sus redes
                EliminarTodasLasRedesDelUsuario(idUsuario);

                // Luego, eliminar el usuario
                string consulta = "DELETE FROM Usuario WHERE ID = @id";
                OleDbParameter[] parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@id", idUsuario)
                };

                return OperacionesBD.EjecutarComando(consulta, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar usuario: {ex.Message}");
                return false;
            }
        }

        // ============================================================================
        //                  EJEMPLOS 4: CONSULTAS AVANZADAS (REPORTS)
        // ============================================================================

        /// <summary>
        /// Obtiene todas las redes de un usuario específico.
        /// </summary>
        public static DataTable ObtenerRedesDelUsuario(int idUsuario)
        {
            try
            {
                string consulta = @"
                    SELECT NombreRed 
                    FROM Redes 
                    WHERE IDUsuario = @idUsuario 
                    ORDER BY NombreRed";

                OleDbParameter[] parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", idUsuario)
                };

                return OperacionesBD.ObtenerDatos(consulta, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener redes: {ex.Message}");
                return new DataTable();
            }
        }

        /// <summary>
        /// Obtiene un reporte con usuario y sus redes (JOIN).
        /// </summary>
        public static DataTable ObtenerReportePorUsuario(int idUsuario)
        {
            try
            {
                string consulta = @"
                    SELECT 
                        u.ID,
                        u.Nombre,
                        u.Apellido,
                        u.Mail,
                        u.Telefono,
                        u.Provincia,
                        u.Localidad,
                        u.Estado,
                        r.NombreRed,
                        u.Latitud,
                        u.Longitud
                    FROM Usuario u
                    LEFT JOIN Redes r ON u.ID = r.IDUsuario
                    WHERE u.ID = @id
                    ORDER BY u.ID";

                OleDbParameter[] parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@id", idUsuario)
                };

                return OperacionesBD.ObtenerDatos(consulta, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener reporte: {ex.Message}");
                return new DataTable();
            }
        }

        /// <summary>
        /// Obtiene estadísticas de usuarios por provincia.
        /// </summary>
        public static DataTable ObtenerEstadisticasPorProvincia()
        {
            try
            {
                string consulta = @"
                    SELECT 
                        Provincia,
                        COUNT(*) AS CantidadUsuarios,
                        COUNT(CASE WHEN Estado = 'Activo' THEN 1 END) AS Activos,
                        COUNT(CASE WHEN Estado = 'Inactivo' THEN 1 END) AS Inactivos
                    FROM Usuario
                    WHERE Provincia IS NOT NULL AND Provincia <> ''
                    GROUP BY Provincia
                    ORDER BY CantidadUsuarios DESC";

                return OperacionesBD.ObtenerDatos(consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener estadísticas: {ex.Message}");
                return new DataTable();
            }
        }

        /// <summary>
        /// Obtiene las redes más populares (cuántos usuarios tienen cada una).
        /// </summary>
        public static DataTable ObtenerRedesPopulares()
        {
            try
            {
                string consulta = @"
                    SELECT 
                        NombreRed,
                        COUNT(*) AS CantidadUsuarios
                    FROM Redes
                    GROUP BY NombreRed
                    ORDER BY CantidadUsuarios DESC";

                return OperacionesBD.ObtenerDatos(consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener redes populares: {ex.Message}");
                return new DataTable();
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios (para cargar en un DataGridView, por ejemplo).
        /// </summary>
        public static DataTable ObtenerTodosLosUsuarios()
        {
            try
            {
                string consulta = @"
                    SELECT 
                        ID,
                        DNI,
                        Nombre,
                        Apellido,
                        Mail,
                        Provincia,
                        Estado,
                        FechaCreacion
                    FROM Usuario
                    ORDER BY Nombre, Apellido";

                return OperacionesBD.ObtenerDatos(consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener usuarios: {ex.Message}");
                return new DataTable();
            }
        }

        // ============================================================================
        //                  EJEMPLOS 5: OPERACIONES DE VALIDACIÓN
        // ============================================================================

        /// <summary>
        /// Verifica si un DNI ya existe en la BD.
        /// </summary>
        public static bool DNIYaExiste(string dni)
        {
            try
            {
                DataTable resultado = BuscarUsuarioPorDNI(dni);
                return resultado.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica si un email ya existe en la BD.
        /// </summary>
        public static bool EmailYaExiste(string email)
        {
            try
            {
                DataTable resultado = BuscarUsuarioPorMail(email);
                return resultado.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene el total de usuarios registrados.
        /// </summary>
        public static int ObtenerTotalUsuarios()
        {
            try
            {
                string consulta = "SELECT COUNT(*) AS Total FROM Usuario";
                DataTable resultado = OperacionesBD.ObtenerDatos(consulta);

                if (resultado.Rows.Count > 0)
                {
                    return Convert.ToInt32(resultado.Rows[0]["Total"]);
                }

                return 0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Obtiene el total de usuarios activos.
        /// </summary>
        public static int ObtenerTotalUsuariosActivos()
        {
            try
            {
                string consulta = "SELECT COUNT(*) AS Total FROM Usuario WHERE Estado = 'Activo'";
                DataTable resultado = OperacionesBD.ObtenerDatos(consulta);

                if (resultado.Rows.Count > 0)
                {
                    return Convert.ToInt32(resultado.Rows[0]["Total"]);
                }

                return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
