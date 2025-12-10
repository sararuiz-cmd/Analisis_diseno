// UI/FrmLogin.cs
using SencomFacturacion.Services;
using System;
using System.Windows.Forms;

namespace SencomFacturacion.UI
{
    public partial class FrmLogin : Form
    {
        private readonly AuthServices _authService;

        public FrmLogin()
        {
            InitializeComponent();
            _authService = new AuthServices();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            txtPassword.UseSystemPasswordChar = true; // asteriscos
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string pass = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Debe ingresar usuario y contraseña.");
                return;
            }

            if (_authService.ValidarLogin(user, pass))
            {
                var frm = new FrmMain(user);
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string pass = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Debe ingresar usuario y contraseña.");
                return;
            }

            if (_authService.RegistrarUsuario(user, pass))
            {
                MessageBox.Show("Usuario registrado correctamente.");
            }
            else
            {
                MessageBox.Show("El usuario ya existe.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void FrmLogin_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cambiar de claro a oscuro o viceversa
            ThemeManager.ToggleTheme();

            // Aplicar el tema a todos los formularios abiertos
            ThemeManager.ApplyThemeToAllOpenForms();

            // Actualizar el texto del botón según el tema actual
            if (ThemeManager.CurrentTheme == ThemeManager.AppTheme.Light)
                button1.Text = "Theme";        // tema original
            else
                button1.Text = "Claro";        // botón para volver al claro
        }

    }
}
