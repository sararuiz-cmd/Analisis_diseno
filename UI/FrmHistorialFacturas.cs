// UI/FrmHistorialFacturas.cs
using SencomFacturacion.Domain;
using SencomFacturacion.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SencomFacturacion.UI
{
    public partial class FrmHistorialFacturas : Form
    {
        private readonly FacturaService _facturaService;
        private readonly PdfService _pdfService;
        private List<Factura> _facturas;

        public FrmHistorialFacturas(FacturaService facturaService)
        {
            InitializeComponent();
            _facturaService = facturaService;
            _pdfService = new PdfService();
        }

        private void FrmHistorialFacturas_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            _facturas = _facturaService.ObtenerFacturas();

            // Limpiar columnas para regenerarlas
            dgvFacturas.Columns.Clear();
            dgvFacturas.DataSource = _facturas;

            // Columnas del cliente
            dgvFacturas.Columns.Add("ClienteNombre", "Cliente");
            dgvFacturas.Columns["ClienteNombre"].DataPropertyName = "Cliente.Nombre";

            dgvFacturas.Columns.Add("Direccion", "Dirección");
            dgvFacturas.Columns["Direccion"].DataPropertyName = "Cliente.Direccion";

            dgvFacturas.Columns.Add("Telefono", "Teléfono");
            dgvFacturas.Columns["Telefono"].DataPropertyName = "Cliente.Telefono";

            dgvFacturas.Columns.Add("Email", "Email");
            dgvFacturas.Columns["Email"].DataPropertyName = "Cliente.Email";
        }


        private Factura ObtenerFacturaSeleccionada()
        {
            if (dgvFacturas.CurrentRow == null) return null;
            return dgvFacturas.CurrentRow.DataBoundItem as Factura;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var factura = ObtenerFacturaSeleccionada();
            if (factura == null)
            {
                MessageBox.Show("Seleccione una factura.");
                return;
            }

            var frm = new FrmFactura(_facturaService, factura);
            frm.ShowDialog();
            CargarFacturas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var factura = ObtenerFacturaSeleccionada();
            if (factura == null)
            {
                MessageBox.Show("Seleccione una factura.");
                return;
            }

            if (MessageBox.Show("¿Eliminar la factura seleccionada?",
                "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _facturaService.EliminarFactura(factura.Id);
                CargarFacturas();
            }
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            var factura = ObtenerFacturaSeleccionada();
            if (factura == null)
            {
                MessageBox.Show("Seleccione una factura.");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = $"Factura_{factura.Id}.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _pdfService.ExportarFactura(factura, sfd.FileName);
                    MessageBox.Show("PDF generado correctamente.");
                }
            }
        }
    }
}
