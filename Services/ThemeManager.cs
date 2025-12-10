using System.Drawing;
using System.Windows.Forms;

namespace SencomFacturacion.Services
{
    // Esta es la clase que maneja los temas de la aplicacion
    public static class ThemeManager
    {
        private static readonly Color ColorPrincipal = ColorTranslator.FromHtml("#003785");
        private static readonly Color ColorSecundario = ColorTranslator.FromHtml("#0EB0AF");
        private static readonly Color ColorFondo = Color.Gainsboro;

        // este es el metodo que aplicara el tema a los formularios
        public static void ApplyTheme(Form form)
        {
            form.BackColor = ColorFondo;
            form.Font = new Font("Segoe UI", 10);

            foreach (Control c in form.Controls)
                ApplyControlTheme(c);
        }

        // Por aca le aplicamos los temas a los controles
        private static void ApplyControlTheme(Control control)
        {
            if (control is Button btn)
            {
                btn.BackColor = ColorSecundario;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
            }
            else if (control is Panel p)
            {
                p.BackColor = ColorPrincipal;
                p.ForeColor = Color.White;
            }
            else if (control is Label lbl)
            {
                lbl.ForeColor = Color.Black;
            }

            foreach (Control child in control.Controls)
                ApplyControlTheme(child);
        }
    }
}
