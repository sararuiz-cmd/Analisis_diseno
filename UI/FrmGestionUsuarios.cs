// UI/FrmGestionUsuarios.cs
using SencomFacturacion.Services;
using System;
using System.Windows.Forms;

namespace SencomFacturacion.UI
{
    public partial class FrmGestionUsuarios : Form
    {
        private readonly AuthServices _authService;

        public FrmGestionUsuarios()
        {
            InitializeComponent();
            _authService = new AuthServices();
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

        private void FrmGestionUsuarios_Load_1(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
