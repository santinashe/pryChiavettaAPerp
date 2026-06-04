using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace pryChiavettaAPerp
{
    public partial class frmPersonal : Form
    {
        // Variable para almacenar el ID del usuario que se acaba de crear
        // La usaremos para guardar las redes sociales asociadas a ese usuario
        private int idUsuarioActual = 0;

        // Variables para almacenar las coordenadas de geolocalización
        private string latitudActual = "0";
        private string longitudActual = "0";

        public frmPersonal()
        {
            InitializeComponent();

            // Conectar eventos de los botones en el constructor
            // Esto es más seguro que hacerlo en el Designer
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnMapa.Click += BtnMapa_Click;
            this.btnLimpiar.Click += BtnLimpiar_Click;
            this.btnCargar.Click += BtnCargar_Click;
            this.btnAtras.Click += BtnAtras_Click;
        }

        // ============================================================================
        //                         EVENTO DEL BOTÓN "GUARDAR"
        // ============================================================================

        /// <summary>
        /// Evento disparado cuando el usuario hace clic en el botón "Guardar".
        /// Coordina todo el proceso: validación, guardado de usuario y redes.
        /// </summary>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Paso 1: Validar que todos los campos estén completos
            if (!ValidarCampos())
            {
                return; // Si falta algo, se detiene el proceso
            }

            // Paso 2: Guardar los datos personales del usuario en la tabla Usuario
            if (!GuardarUsuario())
            {
                return; // Si falla el guardado, se detiene
            }

            // Paso 3: Guardar cada red social seleccionada en la tabla Redes
            GuardarRedesSeleccionadas();

            // Paso 4: Mostrar mensaje de éxito
            MessageBox.Show("✓ Datos guardados correctamente.", 
                "Éxito", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);

            // Paso 5: Limpiar el formulario para permitir cargar otro usuario
            LimpiarFormulario();
        }

        // ============================================================================
        //                        VALIDACIÓN DE CAMPOS
        // ============================================================================

        /// <summary>
        /// Valida que todos los campos obligatorios estén completos.
        /// Si algo falta, muestra un mensaje y devuelve false.
        /// </summary>
        private bool ValidarCampos()
        {
            // Validar DNI
            if (string.IsNullOrWhiteSpace(mtbDNI.Text) || mtbDNI.Text.Replace(" ", "").Length < 8)
            {
                MessageBox.Show("El DNI es obligatorio y debe tener 8 dígitos.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbDNI.Focus();
                return false;
            }

            // Validar Nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El Nombre es obligatorio.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // Validar Apellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El Apellido es obligatorio.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            // Validar Mail (debe contener @)
            if (string.IsNullOrWhiteSpace(txtMail.Text) || !txtMail.Text.Contains("@"))
            {
                MessageBox.Show("El Mail es obligatorio y debe ser válido (debe contener @).", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMail.Focus();
                return false;
            }

            // Validar que al menos una red social esté seleccionada
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debes seleccionar al menos una red social.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; // Todas las validaciones pasaron
        }

        // ============================================================================
        //                      GUARDADO DE DATOS PERSONALES
        // ============================================================================

        /// <summary>
        /// Guarda los datos personales del usuario en la tabla "Usuario".
        /// Utiliza parámetros (@) para evitar inyección de código SQL.
        /// </summary>
        private bool GuardarUsuario()
        {
           
            
            try
            {
               



                // Paso 1: Construir la consulta SQL con parámetros
                // Los símbolos @ indican que lo que sigue es un parámetro, no un texto literal
                // Esto es SEGURO contra inyección SQL
                string consulta = @"
                    INSERT INTO Personal 
                    (Dni, Nombre, Apellido, Direccion, Provincia, Localidad, Actividad) 
                    VALUES 
                    (@dni, @nombre, @apellido, @direccion, @provincia, @localidad, @actividad)";

                // Paso 2: Crear un array con todos los parámetros
                // Cada parámetro tiene un nombre (@) y un valor (el contenido del textbox)
                OleDbParameter[] parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@dni", mtbDNI.Text.Trim()),
                    new OleDbParameter("@nombre", txtNombre.Text.Trim()),
                    new OleDbParameter("@apellido", txtApellido.Text.Trim()),
                    new OleDbParameter("@direccion", txtDireccion.Text.Trim()),
                    new OleDbParameter("@provincia", cmbProvincia.SelectedItem?.ToString() ?? ""),
                    new OleDbParameter("@localidad", cmbLocalidad.SelectedItem?.ToString() ?? ""),                 
                    new OleDbParameter("@usuarioRedes", txtUsuarioRedes.Text.Trim()),
                    // Si chkActivo está marcado, el estado es "Activo", si no, es "Inactivo"
                    new OleDbParameter("@estado", chkActivo.Checked ? "Activo" : "Inactivo")
                };

                // Paso 3: Ejecutar el comando INSERT
                bool resultado = OperacionesBD.EjecutarComando(consulta, parametros);

                if (resultado)
                {
                    // Si se guardó correctamente, obtener el ID del usuario recién creado
                    // Lo necesitamos para guardar las redes asociadas a este usuario
                    idUsuarioActual = OperacionesBD.ObtenerUltimoID(Config.TABLA_USUARIO, "ID");
                }

                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar usuario:\n{ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        
        private void GuardarRedesSeleccionadas()
        {
            try
            {
                // Para cada elemento que el usuario marcó en el CheckedListBox
                foreach (int indice in checkedListBox1.CheckedIndices)
                {
                    // Obtener el nombre de la red social (ej: "Instagram", "TikTok", etc.)
                    string red = checkedListBox1.Items[indice].ToString();

                    // Construir la consulta INSERT para la tabla Redes
                    string consulta = @"
                    INSERT INTO Redes
                    (Instagram, Tiktok, [X], Telegram, Facebook, Mail, Telefono)
                    VALUES
                    (@instagram, @tiktok, @x, @telegram, @facebook, @mail, @telefono)";

                    OleDbParameter[] parametros = new OleDbParameter[]
                    {
                         new OleDbParameter("@instagram", checkedListBox1.Items[indice].ToString()),
                         new OleDbParameter("@tiktok", checkedListBox1.Items[indice].ToString()),
                         new OleDbParameter("@x", checkedListBox1.Items[indice].ToString()),
                         new OleDbParameter("@facebook", checkedListBox1.Items[indice].ToString()),
                         new OleDbParameter("@mail", txtMail.Text.Trim()),
                         new OleDbParameter("@telefono", mtbTelefono.Text.Trim())
                    };

                    // Paso 4: Ejecutar el comando INSERT para la tabla Redes
                    bool resultadoRedes = OperacionesBD.EjecutarComando(consulta, parametros);

                    if (!resultadoRedes)
                    {
                        MessageBox.Show("Error al guardar redes sociales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar redes sociales:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnMapa_Click(object sender, EventArgs e)
        {
            try
            {
                // Paso 1: Obtener las coordenadas según la provincia seleccionada
                // La provincia es importante para localizar correctamente al usuario
                string provinciaCodificada = cmbProvincia.SelectedItem?.ToString() ?? "";
                
                var coordenadas = GeolocalizacionHelper.ObtenerCoordenadas(provinciaCodificada);
                latitudActual = coordenadas.latitud;
                longitudActual = coordenadas.longitud;

                // Paso 2: Validar que las coordenadas sean válidas
                if (!GeolocalizacionHelper.ValidarCoordenadas(latitudActual, longitudActual))
                {
                    MessageBox.Show("Las coordenadas no son válidas.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Paso 3: Abrir Google Maps
                GeolocalizacionHelper.AbrirGoogleMaps(latitudActual, longitudActual, 15);

                MessageBox.Show($"✓ Abriendo mapa en navegador...\n\nUbicación:\nLatitud: {latitudActual}\nLongitud: {longitudActual}", 
                    "Geolocalización", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el mapa:\n{ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================================
        //                  EVENTO DEL BOTÓN "LIMPIAR"
        // ============================================================================

        /// <summary>
        /// Limpia todos los campos del formulario para permitir cargar un nuevo usuario.
        /// </summary>
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            MessageBox.Show("Formulario limpiado.", "Información", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        private void LimpiarFormulario()
        {
            // Limpiar TextBox
            mtbDNI.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtMail.Clear();
            mtbTelefono.Clear();
            txtDireccion.Clear();
            txtUsuarioRedes.Clear();

            // Limpiar ComboBox
            cmbProvincia.SelectedIndex = -1;
            cmbLocalidad.SelectedIndex = -1;

            // Limpiar CheckBox
            chkActivo.Checked = false;
            chkInactivo.Checked = false;

            // Limpiar todas las redes seleccionadas en el CheckedListBox
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            // Reiniciar coordenadas
            latitudActual = "0";
            longitudActual = "0";
            idUsuarioActual = 0;

            // Poner el foco en el primer campo
            mtbDNI.Focus();
        }

       
        private void BtnCargar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de carga de usuario no implementada aún.", 
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        
        private void BtnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
