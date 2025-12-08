// UI/FrmGestionUsuarios.cs
using SencomFacturacion.Services;
using System;
using System.Windows.Forms;

namespace SencomFacturacion.UI
{
    public partial class FrmGestionUsuarios : Form
    {
        private readonly AuthService _authService;

        public FrmGestionUsuarios()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private void FrmGestionUsuarios_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            var lista = _authService.ObtenerUsuarios();
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = lista;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
    }
}
