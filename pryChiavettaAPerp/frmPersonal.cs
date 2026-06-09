using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public partial class frmPersonal : Form
    {
        private ToolTip toolTipFormulario;

        public frmPersonal()
        {
            InitializeComponent();

            btnMapa.Click += BtnMapa_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnCargar.Click += BtnCargar_Click;
            btnAtras.Click += BtnAtras_Click;
            cmbProvincia.SelectedIndexChanged += CmbProvincia_SelectedIndexChanged;

            ConfigurarCombosLocalidad();
            ConfigurarAyudas();
            EnterNavigationHelper.Activar(this, btnCargar);
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            GuardarTodo(
                "Los datos se cargaron correctamente.",
                "No se pudieron guardar los datos. Revisá la información e intentá nuevamente.");
        }

        private void btnCargarTodo_Click(object sender, EventArgs e)
        {
            GuardarTodo(
                "Todos los datos se cargaron correctamente.",
                "No se pudieron guardar todos los datos. Revisá la información e intentá nuevamente.");
        }

        private void GuardarTodo(string mensajeExito, string mensajeError)
        {
            if (!ValidarCampos())
            {
                MessageBox.Show("Completá los campos obligatorios antes de cargar los datos.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string rutaBaseDatos = ObtenerRutaBaseDatos();

                if (rutaBaseDatos == "")
                {
                    return;
                }

                using (OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaBaseDatos + ";"))
                {
                    conexion.Open();
                    AsegurarEstructuraContactos(conexion);

                    using (OleDbTransaction transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            int idPersonal = GuardarDatosPrincipales(conexion, transaccion);
                            GuardarMails(conexion, transaccion, idPersonal);
                            GuardarTelefonos(conexion, transaccion, idPersonal);
                            GuardarRedes(conexion, transaccion, idPersonal);

                            transaccion.Commit();
                            MessageBox.Show(mensajeExito,
                                "Personal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarFormulario();
                        }
                        catch
                        {
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("frmPersonal", "Error", ex.Message);
                MessageBox.Show(mensajeError,
                    "Personal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarMail_Click(object sender, EventArgs e)
        {
            AgregarMail();
        }

        private void btnQuitarMail_Click(object sender, EventArgs e)
        {
            QuitarSeleccionado(lstMails);
        }

        private void btnAgregarTelefono_Click(object sender, EventArgs e)
        {
            AgregarTelefono();
        }

        private void btnQuitarTelefono_Click(object sender, EventArgs e)
        {
            QuitarSeleccionado(lstTelefonos);
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            AgregarRedSocial();
        }

        private void btnQuitarRed_Click(object sender, EventArgs e)
        {
            QuitarSeleccionado(lstRedes);
        }

        private void BtnMapa_Click(object sender, EventArgs e)
        {
            try
            {
                string valor = txtGeo.Text.Trim();

                if (valor == "")
                {
                    valor = txtDireccion.Text.Trim();
                }

                if (valor == "" && !string.IsNullOrWhiteSpace(cmbLocalidad.Text) && !string.IsNullOrWhiteSpace(cmbProvincia.Text))
                {
                    valor = cmbLocalidad.Text.Trim() + ", " + cmbProvincia.Text.Trim() + ", Argentina";
                }

                if (valor == "")
                {
                    MessageBox.Show("Ingresá una dirección, localidad o coordenadas para abrir el mapa.",
                        "Mapa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGeo.Focus();
                    return;
                }

                string url = "https://www.google.com/maps/search/?api=1&query=" + Uri.EscapeDataString(valor);
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al abrir el mapa:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            MessageBox.Show("Formulario limpiado.", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AgregarMail()
        {
            string mail = txtMail.Text.Trim();

            if (mail == "")
            {
                MessageBox.Show("Ingresá un mail antes de agregarlo.", "Mail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMail.Focus();
                return;
            }

            if (!mail.Contains("@"))
            {
                MessageBox.Show("Ingresá un mail válido.", "Mail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMail.Focus();
                return;
            }

            if (ExisteEnLista(lstMails, mail))
            {
                MessageBox.Show("Ese mail ya fue agregado.", "Mail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstMails.Items.Add(mail);
            txtMail.Clear();
            txtMail.Focus();
        }

        private void AgregarTelefono()
        {
            string telefono = mtbTelefono.Text.Trim();

            if (telefono.Replace("-", "").Trim() == "")
            {
                MessageBox.Show("Ingresá un teléfono antes de agregarlo.", "Teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbTelefono.Focus();
                return;
            }

            if (ExisteEnLista(lstTelefonos, telefono))
            {
                MessageBox.Show("Ese teléfono ya fue agregado.", "Teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstTelefonos.Items.Add(telefono);
            mtbTelefono.Clear();
            mtbTelefono.Focus();
        }

        private void AgregarRedSocial()
        {
            string usuario = txtUsuarioRedes.Text.Trim();

            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccioná o ingresá una red social antes de agregarla.",
                    "Red social", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkedListBox1.Focus();
                return;
            }

            if (usuario == "")
            {
                MessageBox.Show("Ingresá el usuario de la red social antes de agregarla.",
                    "Red social", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuarioRedes.Focus();
                return;
            }

            foreach (object item in checkedListBox1.CheckedItems)
            {
                RedSocialCarga red = new RedSocialCarga(item.ToString(), usuario, "");

                if (ExisteRed(red))
                {
                    MessageBox.Show("Esa red social ya fue agregada para ese usuario.",
                        "Red social", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                lstRedes.Items.Add(red);
            }

            txtUsuarioRedes.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(mtbDNI.Text) || mtbDNI.Text.Replace(" ", "").Length < 8)
            {
                MessageBox.Show("El DNI es obligatorio y debe tener 8 dígitos.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbDNI.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbProvincia.Text))
            {
                MessageBox.Show("Primero seleccioná una provincia para ver sus localidades.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProvincia.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbLocalidad.Text))
            {
                MessageBox.Show("Seleccioná una localidad antes de continuar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLocalidad.Focus();
                return false;
            }

            if (lstMails.Items.Count == 0)
            {
                MessageBox.Show("Agregá al menos un mail antes de cargar los datos.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMail.Focus();
                return false;
            }

            if (lstTelefonos.Items.Count == 0)
            {
                MessageBox.Show("Agregá al menos un teléfono antes de cargar los datos.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbTelefono.Focus();
                return false;
            }

            if (lstRedes.Items.Count == 0)
            {
                MessageBox.Show("Agregá al menos una red social antes de cargar los datos.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkedListBox1.Focus();
                return false;
            }

            return true;
        }

        private int GuardarDatosPrincipales(OleDbConnection conexion, OleDbTransaction transaccion)
        {
            string consulta = @"INSERT INTO Personal
                (Dni, Nombre, Apellido, Direccion, Provincia, Localidad, Geo, Actividad)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

            using (OleDbCommand comando = new OleDbCommand(consulta, conexion, transaccion))
            {
                comando.Parameters.AddWithValue("?", mtbDNI.Text.Trim());
                comando.Parameters.AddWithValue("?", txtNombre.Text.Trim());
                comando.Parameters.AddWithValue("?", txtApellido.Text.Trim());
                comando.Parameters.AddWithValue("?", txtDireccion.Text.Trim());
                comando.Parameters.AddWithValue("?", cmbProvincia.Text.Trim());
                comando.Parameters.AddWithValue("?", cmbLocalidad.Text.Trim());
                comando.Parameters.AddWithValue("?", GuardarGeo());
                comando.Parameters.AddWithValue("?", chkActivo.Checked ? "Activo" : "Inactivo");
                comando.ExecuteNonQuery();
            }

            using (OleDbCommand comando = new OleDbCommand("SELECT @@IDENTITY", conexion, transaccion))
            {
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        private void GuardarMails(OleDbConnection conexion, OleDbTransaction transaccion, int idPersonal)
        {
            foreach (object item in lstMails.Items)
            {
                using (OleDbCommand comando = new OleDbCommand(
                    "INSERT INTO PersonalMails (IdPersonal, Mail) VALUES (?, ?)", conexion, transaccion))
                {
                    comando.Parameters.AddWithValue("?", idPersonal);
                    comando.Parameters.AddWithValue("?", item.ToString());
                    comando.ExecuteNonQuery();
                }
            }
        }

        private void GuardarTelefonos(OleDbConnection conexion, OleDbTransaction transaccion, int idPersonal)
        {
            foreach (object item in lstTelefonos.Items)
            {
                using (OleDbCommand comando = new OleDbCommand(
                    "INSERT INTO PersonalTelefonos (IdPersonal, Telefono) VALUES (?, ?)", conexion, transaccion))
                {
                    comando.Parameters.AddWithValue("?", idPersonal);
                    comando.Parameters.AddWithValue("?", item.ToString());
                    comando.ExecuteNonQuery();
                }
            }
        }

        private void GuardarRedes(OleDbConnection conexion, OleDbTransaction transaccion, int idPersonal)
        {
            foreach (object item in lstRedes.Items)
            {
                RedSocialCarga red = item as RedSocialCarga;
                if (red == null)
                {
                    continue;
                }

                using (OleDbCommand comando = new OleDbCommand(
                    "INSERT INTO PersonalRedes (IdPersonal, RedSocial, Usuario, Clave) VALUES (?, ?, ?, ?)", conexion, transaccion))
                {
                    comando.Parameters.AddWithValue("?", idPersonal);
                    comando.Parameters.AddWithValue("?", red.RedSocial);
                    comando.Parameters.AddWithValue("?", red.Usuario);
                    comando.Parameters.AddWithValue("?", red.Clave);
                    comando.ExecuteNonQuery();
                }
            }
        }

        private void AsegurarEstructuraContactos(OleDbConnection conexion)
        {
            if (!TablaExiste(conexion, "PersonalMails"))
            {
                EjecutarDdl(conexion, "CREATE TABLE PersonalMails (Id COUNTER PRIMARY KEY, IdPersonal LONG, Mail TEXT(255))");
            }

            if (!TablaExiste(conexion, "PersonalTelefonos"))
            {
                EjecutarDdl(conexion, "CREATE TABLE PersonalTelefonos (Id COUNTER PRIMARY KEY, IdPersonal LONG, Telefono TEXT(255))");
            }

            if (!TablaExiste(conexion, "PersonalRedes"))
            {
                EjecutarDdl(conexion, "CREATE TABLE PersonalRedes (Id COUNTER PRIMARY KEY, IdPersonal LONG, RedSocial TEXT(255), Usuario TEXT(255), Clave TEXT(255))");
            }

            CrearColumnaGeoSiNoExiste(conexion);
        }

        private string ObtenerRutaBaseDatos()
        {
            string ruta = Config.ObtenerRutaBD();
            return System.IO.File.Exists(ruta) ? ruta : "";
        }

        private string GuardarGeo()
        {
            return txtGeo.Text.Trim();
        }

        private bool ExisteColumnaGeo(OleDbConnection conexion)
        {
            return ColumnaExiste(conexion, "Personal", "Geo");
        }

        private void CrearColumnaGeoSiNoExiste(OleDbConnection conexion)
        {
            if (!ExisteColumnaGeo(conexion))
            {
                EjecutarDdl(conexion, "ALTER TABLE Personal ADD COLUMN Geo TEXT(255)");
            }
        }

        private bool TablaExiste(OleDbConnection conexion, string tabla)
        {
            DataTable esquema = conexion.GetOleDbSchemaTable(
                OleDbSchemaGuid.Tables,
                new object[] { null, null, tabla, "TABLE" });
            return esquema != null && esquema.Rows.Count > 0;
        }

        private bool ColumnaExiste(OleDbConnection conexion, string tabla, string columna)
        {
            DataTable esquema = conexion.GetOleDbSchemaTable(
                OleDbSchemaGuid.Columns,
                new object[] { null, null, tabla, columna });
            return esquema != null && esquema.Rows.Count > 0;
        }

        private void EjecutarDdl(OleDbConnection conexion, string sql)
        {
            using (OleDbCommand comando = new OleDbCommand(sql, conexion))
            {
                comando.ExecuteNonQuery();
            }
        }

        private void LimpiarFormulario()
        {
            mtbDNI.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtMail.Clear();
            mtbTelefono.Clear();
            txtDireccion.Clear();
            txtGeo.Clear();
            txtUsuarioRedes.Clear();
            lstMails.Items.Clear();
            lstTelefonos.Items.Clear();
            lstRedes.Items.Clear();

            cmbProvincia.SelectedIndex = -1;
            cmbLocalidad.Items.Clear();
            cmbLocalidad.Text = "";
            cmbLocalidad.Enabled = false;

            chkActivo.Checked = false;
            chkInactivo.Checked = false;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            mtbDNI.Focus();
        }

        private void ConfigurarCombosLocalidad()
        {
            cmbProvincia.Items.Clear();
            cmbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocalidad.Items.Clear();
            cmbLocalidad.Enabled = false;
            cmbLocalidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbLocalidad.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbLocalidad.DropDownStyle = ComboBoxStyle.DropDown;

            foreach (string provincia in LocalidadesServicio.ObtenerProvincias())
            {
                cmbProvincia.Items.Add(provincia);
            }
        }

        private void CmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLocalidad.Items.Clear();
            cmbLocalidad.Text = "";

            if (string.IsNullOrWhiteSpace(cmbProvincia.Text))
            {
                cmbLocalidad.Enabled = false;
                return;
            }

            foreach (string localidad in LocalidadesServicio.ObtenerLocalidades(cmbProvincia.Text))
            {
                cmbLocalidad.Items.Add(localidad);
            }

            cmbLocalidad.Enabled = true;
        }

        private void ConfigurarAyudas()
        {
            toolTipFormulario = new ToolTip();
            toolTipFormulario.SetToolTip(txtMail, "Ingresá un mail y presioná Agregar.");
            toolTipFormulario.SetToolTip(mtbTelefono, "Ingresá un teléfono y presioná Agregar.");
            toolTipFormulario.SetToolTip(btnGuardar, "Agregar la red social seleccionada a la lista.");
            toolTipFormulario.SetToolTip(cmbProvincia, "Seleccioná una provincia para cargar sus localidades.");
            toolTipFormulario.SetToolTip(cmbLocalidad, "Escribí o seleccioná una localidad de la provincia elegida.");
            toolTipFormulario.SetToolTip(btnMapa, "Abrir Google Maps con la dirección, localidad o coordenadas.");
            toolTipFormulario.SetToolTip(btnCargar, "Guardar todos los datos cargados.");
            toolTipFormulario.SetToolTip(txtGeo, "Ingresá o pegá las coordenadas o ubicación.");
            toolTipFormulario.SetToolTip(btnCargarTodo, "Guardar todos los datos cargados.");
        }

        private void QuitarSeleccionado(ListBox lista)
        {
            if (lista.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un elemento de la lista para quitarlo.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lista.Items.Remove(lista.SelectedItem);
        }

        private bool ExisteEnLista(ListBox lista, string valor)
        {
            foreach (object item in lista.Items)
            {
                if (string.Equals(item.ToString(), valor, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ExisteRed(RedSocialCarga red)
        {
            foreach (object item in lstRedes.Items)
            {
                RedSocialCarga existente = item as RedSocialCarga;
                if (existente != null &&
                    string.Equals(existente.RedSocial, red.RedSocial, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(existente.Usuario, red.Usuario, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private class RedSocialCarga
        {
            public RedSocialCarga(string redSocial, string usuario, string clave)
            {
                RedSocial = redSocial;
                Usuario = usuario;
                Clave = clave;
            }

            public string RedSocial { get; private set; }
            public string Usuario { get; private set; }
            public string Clave { get; private set; }

            public override string ToString()
            {
                return RedSocial + " - " + Usuario;
            }
        }
    }
}
