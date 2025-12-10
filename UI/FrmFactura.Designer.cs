namespace SencomFacturacion.UI
{
    partial class FrmFactura
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnTheme;
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
            this.btnTheme = new System.Windows.Forms.Button();
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
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacidadMensual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeses)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(133)))));
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.btnTheme);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(426, 70);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(18, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(289, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Crear / Editar Factura";
            // 
            // btnTheme
            // 
            this.btnTheme.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnTheme.Location = new System.Drawing.Point(324, 27);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(90, 28);
            this.btnTheme.TabIndex = 1;
            this.btnTheme.Text = "Theme";
            this.btnTheme.UseVisualStyleBackColor = false;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(20, 90);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre del Cliente:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.Location = new System.Drawing.Point(20, 155);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(100, 23);
            this.lblDireccion.TabIndex = 3;
            this.lblDireccion.Text = "Dirección:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.Location = new System.Drawing.Point(20, 220);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(100, 23);
            this.lblTelefono.TabIndex = 5;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(20, 285);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email:";
            // 
            // lblCapacidad
            // 
            this.lblCapacidad.Location = new System.Drawing.Point(20, 350);
            this.lblCapacidad.Name = "lblCapacidad";
            this.lblCapacidad.Size = new System.Drawing.Size(100, 23);
            this.lblCapacidad.TabIndex = 9;
            this.lblCapacidad.Text = "Capacidad Mensual (kW):";
            // 
            // lblMeses
            // 
            this.lblMeses.Location = new System.Drawing.Point(20, 415);
            this.lblMeses.Name = "lblMeses";
            this.lblMeses.Size = new System.Drawing.Size(100, 23);
            this.lblMeses.TabIndex = 11;
            this.lblMeses.Text = "Meses de funcionamiento:";
            // 
            // lblProduccion
            // 
            this.lblProduccion.Location = new System.Drawing.Point(20, 480);
            this.lblProduccion.Name = "lblProduccion";
            this.lblProduccion.Size = new System.Drawing.Size(100, 23);
            this.lblProduccion.TabIndex = 13;
            this.lblProduccion.Text = "Producción mensual (separada por comas):";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(20, 115);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(300, 22);
            this.txtNombreCliente.TabIndex = 2;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(20, 180);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(300, 22);
            this.txtDireccion.TabIndex = 4;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(20, 245);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(300, 22);
            this.txtTelefono.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(20, 310);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 22);
            this.txtEmail.TabIndex = 8;
            // 
            // numCapacidadMensual
            // 
            this.numCapacidadMensual.Location = new System.Drawing.Point(20, 375);
            this.numCapacidadMensual.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCapacidadMensual.Name = "numCapacidadMensual";
            this.numCapacidadMensual.Size = new System.Drawing.Size(120, 22);
            this.numCapacidadMensual.TabIndex = 10;
            // 
            // numMeses
            // 
            this.numMeses.Location = new System.Drawing.Point(20, 440);
            this.numMeses.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numMeses.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMeses.Name = "numMeses";
            this.numMeses.Size = new System.Drawing.Size(120, 22);
            this.numMeses.TabIndex = 12;
            this.numMeses.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtProducciones
            // 
            this.txtProducciones.Location = new System.Drawing.Point(20, 505);
            this.txtProducciones.Multiline = true;
            this.txtProducciones.Name = "txtProducciones";
            this.txtProducciones.Size = new System.Drawing.Size(300, 50);
            this.txtProducciones.TabIndex = 14;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(176)))), ((int)(((byte)(175)))));
            this.btnGuardar.Location = new System.Drawing.Point(20, 570);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(300, 45);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmFactura
            // 
            this.ClientSize = new System.Drawing.Size(426, 650);
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
            this.Name = "FrmFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.FrmFactura_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacidadMensual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
