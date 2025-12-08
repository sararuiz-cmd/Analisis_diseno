namespace SencomFacturacion.UI
{
    partial class FrmGestionUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnRefrescar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnRefrescar = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // PANEL SUPERIOR
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(0, 55, 133);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 70;

            // TÍTULO
            this.lblTitulo.Text = "Gestión de Usuarios";
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);

            // DATAGRIDVIEW
            this.dgvUsuarios.Location = new System.Drawing.Point(20, 100);
            this.dgvUsuarios.Size = new System.Drawing.Size(450, 250);
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // BOTÓN REFRESCAR
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Location = new System.Drawing.Point(20, 370);
            this.btnRefrescar.Size = new System.Drawing.Size(150, 40);
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(14, 176, 175);

            // FORM
            this.ClientSize = new System.Drawing.Size(500, 430);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnRefrescar);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
