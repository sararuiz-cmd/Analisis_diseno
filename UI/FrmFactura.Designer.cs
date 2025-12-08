namespace SencomFacturacion.UI
{
    partial class FrmFactura
    {
        private System.ComponentModel.IContainer components = null;

        // Controles existentes + nuevos
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.Label lblMeses;
        private System.Windows.Forms.Label lblProduccion;

        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.NumericUpDown numCapacidadMensual;
        private System.Windows.Forms.NumericUpDown numMeses;

        private System.Windows.Forms.TextBox txtProducciones;
        private System.Windows.Forms.Button btnGuardar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();

            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.lblMeses = new System.Windows.Forms.Label();
            this.lblProduccion = new System.Windows.Forms.Label();

            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();

            this.numCapacidadMensual = new System.Windows.Forms.NumericUpDown();
            this.numMeses = new System.Windows.Forms.NumericUpDown();

            this.txtProducciones = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numCapacidadMensual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeses)).BeginInit();

            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // PANEL SUPERIOR
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(0, 55, 133);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 70;

            // TÍTULO
            this.lblTitulo.Text = "Crear / Editar Factura";
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(18, 18);

            // LABEL NOMBRE
            this.lblNombre.Text = "Nombre del Cliente:";
            this.lblNombre.Location = new System.Drawing.Point(20, 90);
            this.lblNombre.AutoSize = true;

            this.txtNombreCliente.Location = new System.Drawing.Point(20, 115);
            this.txtNombreCliente.Width = 300;

            // LABEL DIRECCIÓN
            this.lblDireccion.Text = "Dirección:";
            this.lblDireccion.Location = new System.Drawing.Point(20, 155);
            this.lblDireccion.AutoSize = true;

            this.txtDireccion.Location = new System.Drawing.Point(20, 180);
            this.txtDireccion.Width = 300;

            // LABEL TELÉFONO
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Location = new System.Drawing.Point(20, 220);
            this.lblTelefono.AutoSize = true;

            this.txtTelefono.Location = new System.Drawing.Point(20, 245);
            this.txtTelefono.Width = 300;

            // LABEL EMAIL
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(20, 285);
            this.lblEmail.AutoSize = true;

            this.txtEmail.Location = new System.Drawing.Point(20, 310);
            this.txtEmail.Width = 300;

            // LABEL CAPACIDAD
            this.lblCapacidad.Text = "Capacidad Mensual (kW):";
            this.lblCapacidad.Location = new System.Drawing.Point(20, 350);
            this.lblCapacidad.AutoSize = true;

            this.numCapacidadMensual.Location = new System.Drawing.Point(20, 375);
            this.numCapacidadMensual.Maximum = 100000;

            // LABEL MESES
            this.lblMeses.Text = "Meses de funcionamiento:";
            this.lblMeses.Location = new System.Drawing.Point(20, 415);
            this.lblMeses.AutoSize = true;

            this.numMeses.Location = new System.Drawing.Point(20, 440);
            this.numMeses.Minimum = 1;
            this.numMeses.Maximum = 12;

            // LABEL PRODUCCIONES
            this.lblProduccion.Text = "Producción mensual (separada por comas):";
            this.lblProduccion.Location = new System.Drawing.Point(20, 480);
            this.lblProduccion.AutoSize = true;

            this.txtProducciones.Location = new System.Drawing.Point(20, 505);
            this.txtProducciones.Width = 300;
            this.txtProducciones.Height = 50;
            this.txtProducciones.Multiline = true;

            // BOTÓN GUARDAR
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(20, 570);
            this.btnGuardar.Size = new System.Drawing.Size(300, 45);
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(14, 176, 175);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // FORM PRINCIPAL
            this.ClientSize = new System.Drawing.Size(360, 650);
            this.Controls.Add(this.panelTop);

            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombreCliente);

            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtDireccion);

            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);

            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);

            this.Controls.Add(this.lblCapacidad);
            this.Controls.Add(this.numCapacidadMensual);

            this.Controls.Add(this.lblMeses);
            this.Controls.Add(this.numMeses);

            this.Controls.Add(this.lblProduccion);
            this.Controls.Add(this.txtProducciones);

            this.Controls.Add(this.btnGuardar);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura";

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(this.numCapacidadMensual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeses)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
