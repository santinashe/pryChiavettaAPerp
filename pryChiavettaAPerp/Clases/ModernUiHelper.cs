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
                panel.BackColor = Azul;
                return;
            }

            Label label = control as Label;
            if (label != null && label.ForeColor != Color.White)
            {
                label.ForeColor = GrisTexto;
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
