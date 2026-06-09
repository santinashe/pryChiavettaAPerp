using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public partial class frmGestionAuditoria : Form
    {
        private DataTable auditoriaCompleta;
        private Timer timerActualizacion;
        private bool cargandoFiltros;

        public frmGestionAuditoria()
        {
            InitializeComponent();
            EnterNavigationHelper.Activar(this, btnActualizar);
            Load += frmGestionAuditoria_Load;
            FormClosed += frmGestionAuditoria_FormClosed;
        }

        private void frmGestionAuditoria_Load(object sender, EventArgs e)
        {
            try
            {
                PermisosServicio.Exigir(PermisosServicio.PuedeVerAuditoria(), "No tiene permisos para consultar auditoría.");
                PrepararControlesExtendidos();
                ConfigurarGrilla();
                CargarAuditoria();
                AuditoriaServicio.RegistrarAuditoria("frmGestionAuditoria", "Apertura de formulario");
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("frmGestionAuditoria", "Error", ex.Message);
                MessageBox.Show("Error al cargar auditoría: " + ex.Message, "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void frmGestionAuditoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (timerActualizacion != null)
            {
                timerActualizacion.Stop();
                timerActualizacion.Dispose();
            }
        }

        private void Filtro_Cambio(object sender, EventArgs e)
        {
            if (!cargandoFiltros)
            {
                FiltrarAuditoria();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarAuditoria();
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            ExportarCsv();
        }

        private void PrepararControlesExtendidos()
        {
            label2.Text = "Registro de auditoría";
            label1.Text = "Perfil administrador conectado";
            label4.Text = "Usuario";
            label3.Text = "Acción";
            comboBox2.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            timerActualizacion = new Timer();
            timerActualizacion.Interval = 30000;
            timerActualizacion.Tick += (s, e) => CargarAuditoria();
            timerActualizacion.Start();
        }

        private void ConfigurarGrilla()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarAuditoria()
        {
            auditoriaCompleta = AuditoriaServicio.ObtenerAuditoria();
            CargarFiltros();
            FiltrarAuditoria();
        }

        private void CargarFiltros()
        {
            cargandoFiltros = true;

            comboBox2.SelectedIndexChanged -= Filtro_Cambio;
            comboBox2.TextChanged -= Filtro_Cambio;
            comboBox1.SelectedIndexChanged -= Filtro_Cambio;
            comboBox1.TextChanged -= Filtro_Cambio;

            comboBox2.Items.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Add("Todos");
            comboBox1.Items.Add("Todas");

            AgregarValoresUnicos(comboBox2, "Usuario");
            AgregarValoresUnicos(comboBox1, "Movimiento");

            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            comboBox2.SelectedIndexChanged += Filtro_Cambio;
            comboBox2.TextChanged += Filtro_Cambio;
            comboBox1.SelectedIndexChanged += Filtro_Cambio;
            comboBox1.TextChanged += Filtro_Cambio;

            cargandoFiltros = false;
        }

        private void AgregarValoresUnicos(ComboBox combo, string columna)
        {
            if (auditoriaCompleta == null || !auditoriaCompleta.Columns.Contains(columna))
            {
                return;
            }

            foreach (DataRow fila in auditoriaCompleta.Rows)
            {
                string valor = fila[columna] == DBNull.Value ? "" : fila[columna].ToString().Trim();

                if (valor != "" && !combo.Items.Contains(valor))
                {
                    combo.Items.Add(valor);
                }
            }
        }

        private void FiltrarAuditoria()
        {
            if (auditoriaCompleta == null)
            {
                return;
            }

            DataTable filtrada = auditoriaCompleta.Clone();
            string usuario = comboBox2.Text.Trim();
            string accion = comboBox1.Text.Trim();
            string busqueda = txtBuscar == null ? "" : txtBuscar.Text.Trim();
            DateTime desde = dtpDesde == null ? DateTime.MinValue : dtpDesde.Value.Date;
            DateTime hasta = dtpHasta == null ? DateTime.MaxValue : dtpHasta.Value.Date.AddDays(1).AddTicks(-1);

            foreach (DataRow fila in auditoriaCompleta.Rows)
            {
                if (!CoincideCombo(fila, "Usuario", usuario, "Todos")) continue;
                if (!CoincideCombo(fila, "Movimiento", accion, "Todas")) continue;
                if (!CoincideFecha(fila, desde, hasta)) continue;
                if (!CoincideBusqueda(fila, busqueda)) continue;

                filtrada.ImportRow(fila);
            }

            dataGridView1.DataSource = filtrada;
            OrdenarColumnas();
        }

        private bool CoincideCombo(DataRow fila, string columna, string seleccionado, string todos)
        {
            if (seleccionado == "" || seleccionado == todos || !fila.Table.Columns.Contains(columna))
            {
                return true;
            }

            string valor = fila[columna] == DBNull.Value ? "" : fila[columna].ToString();
            return valor.Equals(seleccionado, StringComparison.OrdinalIgnoreCase);
        }

        private bool CoincideFecha(DataRow fila, DateTime desde, DateTime hasta)
        {
            if (!fila.Table.Columns.Contains("FechaHora") || fila["FechaHora"] == DBNull.Value)
            {
                return true;
            }

            DateTime fecha;
            if (!DateTime.TryParse(fila["FechaHora"].ToString(), out fecha))
            {
                return true;
            }

            return fecha >= desde && fecha <= hasta;
        }

        private bool CoincideBusqueda(DataRow fila, string busqueda)
        {
            if (busqueda == "")
            {
                return true;
            }

            foreach (DataColumn columna in fila.Table.Columns)
            {
                string valor = fila[columna] == DBNull.Value ? "" : fila[columna].ToString();
                if (valor.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void OrdenarColumnas()
        {
            MostrarPrimero("IdAuditoria", 0, "ID");
            MostrarPrimero("FechaHora", 1, "Fecha y hora");
            MostrarPrimero("Usuario", 2, "Usuario");
            MostrarPrimero("Rol", 3, "Rol");
            MostrarPrimero("Formulario", 4, "Formulario");
            MostrarPrimero("Movimiento", 5, "Acción");
            MostrarPrimero("Detalle", 6, "Detalle");
        }

        private void MostrarPrimero(string columna, int posicion, string encabezado)
        {
            if (!dataGridView1.Columns.Contains(columna))
            {
                return;
            }

            dataGridView1.Columns[columna].HeaderText = encabezado;
            dataGridView1.Columns[columna].DisplayIndex = Math.Min(posicion, dataGridView1.Columns.Count - 1);
        }

        private void ExportarCsv()
        {
            try
            {
                DataTable tabla = dataGridView1.DataSource as DataTable;

                if (tabla == null || tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros para exportar.", "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog dialogo = new SaveFileDialog())
                {
                    dialogo.Filter = "CSV (*.csv)|*.csv";
                    dialogo.FileName = "auditoria_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

                    if (dialogo.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    StringBuilder csv = new StringBuilder();

                    for (int i = 0; i < tabla.Columns.Count; i++)
                    {
                        if (i > 0) csv.Append(";");
                        csv.Append(EscaparCsv(tabla.Columns[i].ColumnName));
                    }

                    csv.AppendLine();

                    foreach (DataRow fila in tabla.Rows)
                    {
                        for (int i = 0; i < tabla.Columns.Count; i++)
                        {
                            if (i > 0) csv.Append(";");
                            csv.Append(EscaparCsv(fila[i].ToString()));
                        }

                        csv.AppendLine();
                    }

                    File.WriteAllText(dialogo.FileName, csv.ToString(), Encoding.UTF8);
                    AuditoriaServicio.RegistrarAuditoria("frmGestionAuditoria", "Exportación CSV", dialogo.FileName);
                    MessageBox.Show("Exportación finalizada.", "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                AuditoriaServicio.RegistrarAuditoria("frmGestionAuditoria", "Error", ex.Message);
                MessageBox.Show("Error al exportar CSV: " + ex.Message, "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string EscaparCsv(string valor)
        {
            if (valor == null)
            {
                return "";
            }

            string limpio = valor.Replace("\"", "\"\"");
            return "\"" + limpio + "\"";
        }
    }
}
