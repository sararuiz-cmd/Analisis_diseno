using System;
using System.Drawing;
using System.Windows.Forms;

namespace SencomFacturacion.Services
{
    public static class ThemeManager
    {
        public enum AppTheme
        {
            Light,
            Dark
        }

        // Tema actual (por defecto el original: claro)
        public static AppTheme CurrentTheme { get; private set; } = AppTheme.Light;

        // Cambia entre claro y oscuro
        public static void ToggleTheme()
        {
            CurrentTheme = CurrentTheme == AppTheme.Light
                ? AppTheme.Dark
                : AppTheme.Light;
        }

        // Aplica el tema SOLO a un form
        public static void ApplyTheme(Form form)
        {
            // Paleta según el tema
            Color colorPrincipal;
            Color colorSecundario;
            Color colorFondo;
            Color colorTexto;
            Color colorTextoInverso;
            Color colorInputFondo;

            if (CurrentTheme == AppTheme.Light)
            {
                // Tema original
                colorPrincipal = ColorTranslator.FromHtml("#003785"); // azul
                colorSecundario = ColorTranslator.FromHtml("#0EB0AF"); // turquesa
                colorFondo = Color.Gainsboro;                      // gris claro
                colorTexto = Color.Black;
                colorTextoInverso = Color.White;
                colorInputFondo = Color.White;
            }
            else
            {
                // Tema oscuro
                colorPrincipal = Color.FromArgb(10, 25, 60);   // azul muy oscuro
                colorSecundario = Color.FromArgb(10, 120, 120); // turquesa oscuro
                colorFondo = Color.FromArgb(30, 30, 30);   // casi negro
                colorTexto = Color.WhiteSmoke;
                colorTextoInverso = Color.White;
                colorInputFondo = Color.FromArgb(45, 45, 45);
            }

            form.BackColor = colorFondo;
            form.Font = new Font("Segoe UI", 10);

            ApplyThemeToControls(form.Controls, colorPrincipal, colorSecundario,
                                 colorFondo, colorTexto, colorTextoInverso, colorInputFondo);
        }

        // Aplica el tema a TODOS los formularios abiertos
        public static void ApplyThemeToAllOpenForms()
        {
            foreach (Form f in Application.OpenForms)
            {
                ApplyTheme(f);
            }
        }

        private static void ApplyThemeToControls(
            Control.ControlCollection controls,
            Color colorPrincipal,
            Color colorSecundario,
            Color colorFondo,
            Color colorTexto,
            Color colorTextoInverso,
            Color colorInputFondo)
        {
            foreach (Control c in controls)
            {
                switch (c)
                {
                    case Panel p:
                        p.BackColor = colorPrincipal;
                        p.ForeColor = colorTextoInverso;
                        break;

                    case Button b:
                        b.BackColor = colorSecundario;
                        b.ForeColor = colorTextoInverso;
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        break;

                    case Label lbl:
                        lbl.ForeColor = colorTexto;
                        break;

                    case TextBox txt:
                        txt.BackColor = colorInputFondo;
                        txt.ForeColor = colorTexto;
                        txt.BorderStyle = BorderStyle.FixedSingle;
                        break;

                    case DataGridView dgv:
                        dgv.BackgroundColor = colorFondo;
                        dgv.ForeColor = colorTexto;
                        dgv.EnableHeadersVisualStyles = false;
                        dgv.ColumnHeadersDefaultCellStyle.BackColor = colorPrincipal;
                        dgv.ColumnHeadersDefaultCellStyle.ForeColor = colorTextoInverso;
                        dgv.RowHeadersVisible = false;
                        break;
                }

                if (c.HasChildren)
                {
                    ApplyThemeToControls(c.Controls, colorPrincipal, colorSecundario,
                                         colorFondo, colorTexto, colorTextoInverso, colorInputFondo);
                }
            }
        }
    }
}
