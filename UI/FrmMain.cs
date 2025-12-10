// UI/FrmMain.cs
using SencomFacturacion.Services;
using System;
using System.Windows.Forms;

namespace SencomFacturacion.UI
{
    public partial class FrmMain : Form
    {
        private readonly string _usuarioActual;
        private readonly FacturaService _facturaService;

        public FrmMain(string usuarioActual)
        {
            InitializeComponent();
            _usuarioActual = usuarioActual;
            _facturaService = new FacturaService();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            this.Text = $"SENCOM - Menú principal ({_usuarioActual})";
        }

        private void btnNuevaFactura_Click(object sender, EventArgs e)
        {
            var frm = new FrmFactura(_facturaService);
            frm.ShowDialog();
            ThemeManager.ApplyThemeToAllOpenForms(); // volver a aplicar por si cambia el tema
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            var frm = new FrmHistorialFacturas(_facturaService);
            frm.ShowDialog();
            ThemeManager.ApplyThemeToAllOpenForms();
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            var frm = new FrmGestionUsuarios();
            frm.ShowDialog();
            ThemeManager.ApplyThemeToAllOpenForms();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 🔥 BOTÓN THEME (NUEVO)
        private void btnTheme_Click(object sender, EventArgs e)
        {
            ThemeManager.ToggleTheme();              // Cambia entre Light/Dark
            ThemeManager.ApplyThemeToAllOpenForms(); // Aplica el tema a todos los forms abiertos
        }
    }
}
