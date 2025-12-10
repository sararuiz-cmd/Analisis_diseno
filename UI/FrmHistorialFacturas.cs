// UI/FrmHistorialFacturas.cs
using SencomFacturacion.Domain;
using SencomFacturacion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

            // Debug rápido para saber cuántas se leyeron
            // (lo puedes quitar luego)
            MessageBox.Show($"Facturas leídas: {_facturas.Count}", "Debug");

            if (_facturas == null || _facturas.Count == 0)
            {
                dgvFacturas.DataSource = null;
                return;
            }

            // Proyección PLANA para el DataGridView (sin propiedades anidadas)
            var data = _facturas.Select(f => new
            {
                ID = f.Id,
                Cliente = f.Cliente?.Nombre,
                Direccion = f.Cliente?.Direccion,
                Telefono = f.Cliente?.Telefono,
                Email = f.Cliente?.Email,
                Consumo = f.ConsumoTotalKw,
                Monto = f.MontoTotal,
                Fecha = f.FechaCreacion
            }).ToList();

            dgvFacturas.AutoGenerateColumns = true;
            dgvFacturas.DataSource = null;      // forzar refresh
            dgvFacturas.DataSource = data;
        }




        private Factura ObtenerFacturaSeleccionada()
        {
            if (dgvFacturas.CurrentRow == null) return null;

            int id = Convert.ToInt32(dgvFacturas.CurrentRow.Cells["ID"].Value);

            return _facturas.FirstOrDefault(f => f.Id == id);
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

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
