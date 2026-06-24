using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace pryChiavettaAPerp
{
    public static class ModernUiHelper
    {
        private static readonly Dictionary<Form, List<Component>> ComponentesVisuales = new Dictionary<Form, List<Component>>();

        private static readonly Color Azul = Color.FromArgb(37, 99, 235);
        private static readonly Color AzulHover = Color.FromArgb(29, 78, 216);
        private static readonly Color GrisFondo = Color.FromArgb(248, 250, 252);
        private static readonly Color GrisBorde = Color.FromArgb(203, 213, 225);
        private static readonly Color GrisTexto = Color.FromArgb(51, 65, 85);
        private static readonly Color Rojo = Color.FromArgb(220, 38, 38);
        private static readonly Color RojoHover = Color.FromArgb(185, 28, 28);

        public static void Aplicar(Form formulario)
        {
            if (formulario == null)
            {
                return;
            }

            if (EstaEnDisenio(formulario))
            {
                return;
            }

            formulario.BackColor = Color.White;
            formulario.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);

            RegistrarComponentes(formulario);
            AplicarDistribucion(formulario);
            formulario.Shown -= Formulario_Shown;
            formulario.Shown += Formulario_Shown;
            formulario.Resize -= Formulario_Resize;
            formulario.Resize += Formulario_Resize;
            AplicarAControles(formulario.Controls);
        }

        private static bool EstaEnDisenio(Form formulario)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
                (formulario.Site != null && formulario.Site.DesignMode))
            {
                return true;
            }

            string proceso = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            return string.Equals(proceso, "devenv", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(proceso, "XDesProc", StringComparison.OrdinalIgnoreCase);
        }

        private static void RegistrarComponentes(Form formulario)
        {
            if (ComponentesVisuales.ContainsKey(formulario))
            {
                return;
            }

            List<Component> componentes = new List<Component>();

            Guna2ShadowForm shadowForm = new Guna2ShadowForm
            {
                TargetForm = formulario,
                ShadowColor = Color.FromArgb(148, 163, 184)
            };
            componentes.Add(shadowForm);

            Control barraSuperior = BuscarBarraSuperior(formulario.Controls);
            if (barraSuperior != null)
            {
                Guna2DragControl dragControl = new Guna2DragControl
                {
                    TargetControl = barraSuperior,
                    UseTransparentDrag = true
                };
                componentes.Add(dragControl);
            }

            ComponentesVisuales[formulario] = componentes;
            formulario.FormClosed += Formulario_FormClosed;
        }

        private static Control BuscarBarraSuperior(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control.Name == "panel1")
                {
                    return control;
                }
            }

            return null;
        }

        private static void AplicarAControles(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                AplicarEstilo(control);

                if (control.HasChildren)
                {
                    AplicarAControles(control.Controls);
                }
            }
        }

        private static void AplicarEstilo(Control control)
        {
            Label label = control as Label;
            if (label != null)
            {
                if (label.Parent != null && string.Equals(label.Parent.Name, "panel1", StringComparison.OrdinalIgnoreCase))
                {
                    label.AutoSize = false;
                    label.Width = label.Parent.ClientSize.Width;
                    label.Left = 0;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    float tamano = Math.Min(Math.Max(label.Font.Size, 12F), 26F);
                    label.Font = new Font("Segoe UI Semibold", tamano, FontStyle.Bold, GraphicsUnit.Point, 0);
                }
                else
                {
                    label.Font = new Font("Segoe UI Semibold", label.Font.Size, label.Font.Style, GraphicsUnit.Point, 0);
                }

                if (label.ForeColor != Color.White)
                {
                    label.ForeColor = GrisTexto;
                }

                return;
            }

            control.Font = new Font("Segoe UI", 10F, control.Font.Style, GraphicsUnit.Point, 0);

            Button boton = control as Button;
            if (boton != null)
            {
                AplicarBoton(boton);
                return;
            }

            TextBox textBox = control as TextBox;
            if (textBox != null)
            {
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.BackColor = Color.White;
                textBox.ForeColor = GrisTexto;
                return;
            }

            Guna2ComboBox comboGuna = control as Guna2ComboBox;
            if (comboGuna != null)
            {
                comboGuna.BorderRadius = 6;
                comboGuna.BorderColor = GrisBorde;
                comboGuna.FillColor = Color.White;
                comboGuna.ForeColor = GrisTexto;
                return;
            }

            ComboBox comboBox = control as ComboBox;
            if (comboBox != null)
            {
                comboBox.BackColor = Color.White;
                comboBox.ForeColor = GrisTexto;
                return;
            }

            CheckBox checkBox = control as CheckBox;
            if (checkBox != null)
            {
                checkBox.Cursor = Cursors.Hand;
                checkBox.ForeColor = GrisTexto;
                return;
            }

            Guna2DataGridView grillaGuna = control as Guna2DataGridView;
            if (grillaGuna != null)
            {
                AplicarGrilla(grillaGuna);
                grillaGuna.ThemeStyle.HeaderStyle.BackColor = Azul;
                grillaGuna.ThemeStyle.HeaderStyle.ForeColor = Color.White;
                grillaGuna.ThemeStyle.RowsStyle.BackColor = Color.White;
                grillaGuna.ThemeStyle.AlternatingRowsStyle.BackColor = GrisFondo;
                return;
            }

            DataGridView dataGridView = control as DataGridView;
            if (dataGridView != null)
            {
                AplicarGrilla(dataGridView);
                return;
            }

            Guna2Panel panelGuna = control as Guna2Panel;
            if (panelGuna != null)
            {
                panelGuna.BorderRadius = 8;
                panelGuna.FillColor = panelGuna.Name == "panel1" ? Azul : GrisFondo;
                return;
            }

            Guna2GroupBox groupBoxGuna = control as Guna2GroupBox;
            if (groupBoxGuna != null)
            {
                groupBoxGuna.BorderRadius = 8;
                groupBoxGuna.BorderColor = GrisBorde;
                groupBoxGuna.CustomBorderColor = Azul;
                groupBoxGuna.FillColor = Color.White;
                groupBoxGuna.ForeColor = Color.White;
                return;
            }

            Panel panel = control as Panel;
            if (panel != null && panel.Name == "panel1")
            {
                panel.Location = new Point(0, panel.Location.Y);
                panel.Width = panel.Parent != null ? panel.Parent.ClientSize.Width : panel.Width;
                panel.BackColor = Azul;
                return;
            }
        }

        private static void AplicarBoton(Button boton)
        {
            boton.Cursor = Cursors.Hand;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.ForeColor = Color.White;

            if (boton.Text.IndexOf("salir", StringComparison.OrdinalIgnoreCase) >= 0 ||
                boton.Text.IndexOf("cerrar", StringComparison.OrdinalIgnoreCase) >= 0 ||
                boton.Name.IndexOf("atras", StringComparison.OrdinalIgnoreCase) >= 0 ||
                boton.Name.IndexOf("baja", StringComparison.OrdinalIgnoreCase) >= 0 ||
                boton.Name.IndexOf("quitar", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                boton.BackColor = Rojo;
                boton.FlatAppearance.MouseOverBackColor = RojoHover;
                return;
            }

            boton.BackColor = Azul;
            boton.FlatAppearance.MouseOverBackColor = AzulHover;
        }

        private static void AplicarGrilla(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Azul;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dataGridView.DefaultCellStyle.ForeColor = GrisTexto;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dataGridView.DefaultCellStyle.SelectionForeColor = GrisTexto;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = GrisFondo;
            dataGridView.GridColor = GrisBorde;
        }

        private static void AplicarDistribucion(Form formulario)
        {
            AjustarBarraSuperior(formulario);
            AjustarBotonesPrincipales(formulario);
            AjustarBotonesEspecificos(formulario);
        }

        private static void AjustarBarraSuperior(Form formulario)
        {
            Panel panel = BuscarControl(formulario.Controls, "panel1") as Panel;
            if (panel == null)
            {
                return;
            }

            panel.Location = new Point(0, panel.Location.Y);
            panel.Width = formulario.ClientSize.Width;

            if (formulario.Name == "frmBienvenida")
            {
                panel.Location = new Point(0, 0);
            }
        }

        private static void AjustarBotonesPrincipales(Form formulario)
        {
            if (formulario.Name == "frmPrinicipal")
            {
                CentrarFilaBotones(formulario, 309, 16, "btnSalir", "btnIngresar");
                return;
            }

            if (formulario.Name == "frmBienvenida")
            {
                CentrarFilaBotones(formulario, 346, 16, "btnCerrar", "bntIngresar");
                return;
            }

            if (formulario.Name == "frmAcciones")
            {
                AjustarAcciones(formulario);
                return;
            }

            if (formulario.Name == "frmGestionAuditoria")
            {
                CentrarFilaBotones(formulario, 223, 24, "btnActualizar", "btnExportarCsv");
            }
        }

        private static void AjustarBotonesEspecificos(Form formulario)
        {
            if (formulario.Name == "frmGestionUsuarios")
            {
                Control btnAlta = BuscarControl(formulario.Controls, "btnAlta");
                Control btnModificar = BuscarControl(formulario.Controls, "btnModificar");
                Control btnBaja = BuscarControl(formulario.Controls, "btnBaja");
                Control btnLimpiar = BuscarControl(formulario.Controls, "btnLimpiar");

                if (btnAlta != null) btnAlta.Top = 494;
                if (btnModificar != null) btnModificar.Top = 494;
                if (btnBaja != null) btnBaja.Top = 556;
                if (btnLimpiar != null) btnLimpiar.Top = 556;
            }

            if (formulario.Name == "frmGestionAuditoria" || formulario.Name == "frmPersonal")
            {
                Control btnAtras = BuscarControl(formulario.Controls, "btnAtras");
                if (btnAtras != null)
                {
                    btnAtras.Text = "<";
                }
            }
        }

        private static void AjustarAcciones(Form formulario)
        {
            Panel panel = BuscarControl(formulario.Controls, "panel1") as Panel;
            if (panel != null)
            {
                panel.Height = 100;
                panel.Location = new Point(0, 0);
                panel.Width = formulario.ClientSize.Width;
            }

            Label titulo = BuscarControl(formulario.Controls, "label1") as Label;
            if (titulo != null)
            {
                titulo.AutoSize = false;
                titulo.Left = 0;
                titulo.Top = 6;
                titulo.Width = formulario.ClientSize.Width;
                titulo.Height = 44;
                titulo.TextAlign = ContentAlignment.MiddleCenter;
                titulo.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            }

            Label subtitulo = BuscarControl(formulario.Controls, "label2") as Label;
            if (subtitulo != null)
            {
                subtitulo.AutoSize = false;
                subtitulo.Left = 0;
                subtitulo.Top = 50;
                subtitulo.Width = formulario.ClientSize.Width;
                subtitulo.Height = 28;
                subtitulo.TextAlign = ContentAlignment.MiddleCenter;
                subtitulo.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            }

            DateTimePicker fecha = BuscarControl(formulario.Controls, "dateTimePicker1") as DateTimePicker;
            if (fecha != null)
            {
                fecha.Width = 380;
                fecha.Height = 28;
                fecha.Left = Math.Max(0, (formulario.ClientSize.Width - fecha.Width) / 2);
                fecha.Top = 128;
            }

            PictureBox imagen = BuscarControl(formulario.Controls, "pictureBox1") as PictureBox;
            if (imagen != null)
            {
                imagen.SizeMode = PictureBoxSizeMode.Zoom;
                imagen.Size = new Size(320, 320);
                imagen.Left = Math.Max(0, (formulario.ClientSize.Width - imagen.Width) / 2);
                imagen.Top = 205;
            }

            int botonAncho = 240;
            int botonAlto = 90;
            int botonTop1 = 320;
            int botonTop2 = 520;
            int izquierda = Math.Max(24, (formulario.ClientSize.Width / 2) - imagen.Width / 2 - botonAncho - 60);
            int derecha = Math.Min(formulario.ClientSize.Width - botonAncho - 24, (formulario.ClientSize.Width / 2) + imagen.Width / 2 + 60);

            AplicarTamanioBoton(formulario, "button2", izquierda, botonTop1, botonAncho, botonAlto);
            AplicarTamanioBoton(formulario, "button3", izquierda, botonTop2, botonAncho, botonAlto);
            AplicarTamanioBoton(formulario, "button1", derecha, botonTop1, botonAncho, botonAlto);
            AplicarTamanioBoton(formulario, "button5", derecha, botonTop2, botonAncho, botonAlto);
        }

        private static void AplicarTamanioBoton(Form formulario, string nombre, int left, int top, int width, int height)
        {
            Button boton = BuscarControl(formulario.Controls, nombre) as Button;
            if (boton == null)
            {
                return;
            }

            boton.Left = left;
            boton.Top = top;
            boton.Width = width;
            boton.Height = height;
        }

        private static void Formulario_Shown(object sender, EventArgs e)
        {
            Form formulario = sender as Form;
            if (formulario != null)
            {
                AplicarDistribucion(formulario);
            }
        }

        private static void Formulario_Resize(object sender, EventArgs e)
        {
            Form formulario = sender as Form;
            if (formulario != null)
            {
                AplicarDistribucion(formulario);
            }
        }

        private static void CentrarFilaBotones(Form formulario, int top, int gap, params string[] nombres)
        {
            List<Button> botones = new List<Button>();

            foreach (string nombre in nombres)
            {
                Button boton = BuscarControl(formulario.Controls, nombre) as Button;
                if (boton != null)
                {
                    botones.Add(boton);
                }
            }

            if (botones.Count == 0)
            {
                return;
            }

            int anchoTotal = 0;
            for (int i = 0; i < botones.Count; i++)
            {
                anchoTotal += botones[i].Width;
                if (i < botones.Count - 1)
                {
                    anchoTotal += gap;
                }
            }

            int inicioX = Math.Max(0, (formulario.ClientSize.Width - anchoTotal) / 2);

            foreach (Button boton in botones)
            {
                boton.Top = top;
                boton.Left = inicioX;
                inicioX += boton.Width + gap;
            }
        }

        private static Control BuscarControl(Control.ControlCollection controles, string nombre)
        {
            foreach (Control control in controles)
            {
                if (string.Equals(control.Name, nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return control;
                }

                if (control.HasChildren)
                {
                    Control encontrado = BuscarControl(control.Controls, nombre);
                    if (encontrado != null)
                    {
                        return encontrado;
                    }
                }
            }

            return null;
        }

        private static void Formulario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form formulario = sender as Form;
            if (formulario == null || !ComponentesVisuales.ContainsKey(formulario))
            {
                return;
            }

            foreach (Component componente in ComponentesVisuales[formulario])
            {
                componente.Dispose();
            }

            ComponentesVisuales.Remove(formulario);
        }
    }
}
