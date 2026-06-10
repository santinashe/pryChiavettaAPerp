using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace pryChiavettaAPerp
{
    public static class EnterNavigationHelper
    {
        private static readonly Dictionary<Form, Button> BotonesPrincipales = new Dictionary<Form, Button>();

        public static void Activar(Form formulario, Button botonPrincipalOpcional = null)
        {
            if (formulario == null)
            {
                return;
            }

            BotonesPrincipales[formulario] = botonPrincipalOpcional;
            formulario.FormClosed -= Formulario_FormClosed;
            formulario.FormClosed += Formulario_FormClosed;
            AplicarAControles(formulario.Controls);
        }

        private static void AplicarAControles(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                control.KeyDown -= Control_KeyDown;
                control.KeyDown += Control_KeyDown;

                if (control.HasChildren)
                {
                    AplicarAControles(control.Controls);
                }
            }
        }

        private static void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || e.Control || e.Alt || e.Shift)
            {
                return;
            }

            Control control = sender as Control;
            Form formulario = control == null ? null : control.FindForm();

            if (formulario == null || control is ButtonBase || control is DataGridView)
            {
                return;
            }

            TextBoxBase textBox = control as TextBoxBase;
            if (textBox != null && textBox.Multiline)
            {
                return;
            }

            e.SuppressKeyPress = true;

            Button botonPrincipal;
            if (BotonesPrincipales.TryGetValue(formulario, out botonPrincipal) &&
                botonPrincipal != null &&
                botonPrincipal.Enabled &&
                CamposPrincipalesCompletos(formulario))
            {
                botonPrincipal.PerformClick();
                return;
            }

            formulario.SelectNextControl(control, true, true, true, true);
        }

        private static bool CamposPrincipalesCompletos(Form formulario)
        {
            bool hayCampo = false;
            return CamposCompletos(formulario.Controls, ref hayCampo) && hayCampo;
        }

        private static bool CamposCompletos(Control.ControlCollection controles, ref bool hayCampo)
        {
            foreach (Control control in controles)
            {
                if (!control.Visible || !control.Enabled)
                {
                    continue;
                }

                TextBoxBase textBox = control as TextBoxBase;
                if (textBox != null && !textBox.ReadOnly && !textBox.Multiline)
                {
                    hayCampo = true;
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return false;
                    }
                }

                ComboBox comboBox = control as ComboBox;
                if (comboBox != null)
                {
                    hayCampo = true;
                    if (string.IsNullOrWhiteSpace(comboBox.Text))
                    {
                        return false;
                    }
                }

                if (control.HasChildren && !CamposCompletos(control.Controls, ref hayCampo))
                {
                    return false;
                }
            }

            return true;
        }

        private static void Formulario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form formulario = sender as Form;
            if (formulario != null && BotonesPrincipales.ContainsKey(formulario))
            {
                BotonesPrincipales.Remove(formulario);
            }
        }
    }
}
