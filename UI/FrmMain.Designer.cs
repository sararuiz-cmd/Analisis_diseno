namespace SencomFacturacion.UI
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnNuevaFactura;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnNuevaFactura = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnGestionUsuarios = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(133)))));
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(386, 70);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(348, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "SENCOM - Menú Principal";
            // 
            // btnNuevaFactura
            // 
            this.btnNuevaFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(176)))), ((int)(((byte)(175)))));
            this.btnNuevaFactura.Location = new System.Drawing.Point(73, 100);
            this.btnNuevaFactura.Name = "btnNuevaFactura";
            this.btnNuevaFactura.Size = new System.Drawing.Size(250, 50);
            this.btnNuevaFactura.TabIndex = 1;
            this.btnNuevaFactura.Text = "Crear Nueva Factura";
            this.btnNuevaFactura.UseVisualStyleBackColor = false;
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(176)))), ((int)(((byte)(175)))));
            this.btnHistorial.Location = new System.Drawing.Point(73, 166);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(250, 50);
            this.btnHistorial.TabIndex = 2;
            this.btnHistorial.Text = "Historial de Facturas";
            this.btnHistorial.UseVisualStyleBackColor = false;
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(176)))), ((int)(((byte)(175)))));
            this.btnGestionUsuarios.Location = new System.Drawing.Point(73, 234);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(250, 50);
            this.btnGestionUsuarios.TabIndex = 3;
            this.btnGestionUsuarios.Text = "Gestión de Usuarios";
            this.btnGestionUsuarios.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(73, 310);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(250, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(386, 400);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.btnNuevaFactura);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnGestionUsuarios);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
