using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    /// <summary>
    /// Clase para gestionar operaciones comunes con la base de datos.
    /// Contiene métodos reutilizables para INSERT, UPDATE, DELETE y SELECT.
    /// </summary>
    public class OperacionesBD
    {
        /// <summary>
        /// Ejecuta un comando SQL (INSERT, UPDATE o DELETE) con parámetros.
        /// 
        /// Parámetros evitan inyección SQL porque el valor no se concatena directamente
        /// en la consulta, sino que se pasa de forma segura.
        /// </summary>
        /// <param name="consulta">Consulta SQL con parámetros (ej: @nombre, @apellido)</param>
        /// <param name="parametros">Array de OleDbParameter con los valores</param>
        /// <returns>true si se ejecutó sin errores, false si hubo error</returns>
        public static bool EjecutarComando(string consulta, OleDbParameter[] parametros = null)
        {
            try
            {
                // Usando 'using' para asegurar que la conexión se cierre automáticamente
                using (OleDbConnection conexion = new OleDbConnection(Config.CadenaConexion))
                {
                    conexion.Open();

                    // Crear el comando con la consulta
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        // Agregar parámetros si existen (previene inyección SQL)
                        if (parametros != null)
                        {
                            comando.Parameters.AddRange(parametros);
                        }

                        // Ejecutar el comando (INSERT, UPDATE o DELETE)
                        comando.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("OperacionesBD", "Error", ex.Message + "\n" + consulta);
                MessageBox.Show($"Error al ejecutar comando:\n{ex.Message}", 
                    "Error de Base de Datos", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Ejecuta una consulta SELECT y retorna los resultados en un DataTable.
        /// DataTable es como una tabla en memoria que podemos trabajar fácilmente.
        /// </summary>
        /// <param name="consulta">Consulta SELECT con parámetros si es necesario</param>
        /// <param name="parametros">Array de OleDbParameter</param>
        /// <returns>DataTable con los resultados. Si hay error, retorna un DataTable vacío.</returns>
        public static DataTable ObtenerDatos(string consulta, OleDbParameter[] parametros = null)
        {
            DataTable datos = new DataTable();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(Config.CadenaConexion))
                {
                    conexion.Open();

                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        if (parametros != null)
                        {
                            comando.Parameters.AddRange(parametros);
                        }

                        // OleDbDataAdapter es como un puente que llena el DataTable con los resultados
                        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
                        adaptador.Fill(datos);
                    }
                }
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("OperacionesBD", "Error", ex.Message + "\n" + consulta);
                MessageBox.Show($"Error al obtener datos:\n{ex.Message}", 
                    "Error de Base de Datos", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }

            return datos;
        }

        /// <summary>
        /// Obtiene el ID más alto de una tabla (útil después de insertar un registro).
        /// Esto nos permite saber cuál fue el ID del registro que acabamos de crear.
        /// </summary>
        /// <param name="tabla">Nombre de la tabla (ej: "Usuario")</param>
        /// <param name="campoID">Nombre del campo ID (ej: "ID")</param>
        /// <returns>El ID más alto, o 0 si no hay registros</returns>
        public static int ObtenerUltimoID(string tabla, string campoID)
        {
            try
            {
                string consulta = $"SELECT MAX({campoID}) AS UltimoID FROM {tabla}";
                DataTable datos = ObtenerDatos(consulta);

                // Verificar si hay datos y si el valor no es nulo
                if (datos.Rows.Count > 0 && datos.Rows[0]["UltimoID"] != DBNull.Value)
                {
                    return Convert.ToInt32(datos.Rows[0]["UltimoID"]);
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
