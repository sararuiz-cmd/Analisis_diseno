using SencomFacturacion.Domain;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Analisis_diseno.Services
{
    public class PdfService
    {
        public void ExportarFactura(Factura factura, string ruta)
        {
            using var fs = new FileStream(ruta, FileMode.Create);
            using var doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(doc, fs);
            doc.Open();

            doc.Add(new Paragraph("Factura SENCOM", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)));
            doc.Add(new Paragraph(""));

            doc.Add(new Paragraph($"Cliente: {factura.Cliente.Nombre}"));
            doc.Add(new Paragraph($"Dirección: {factura.Cliente.Direccion}"));
            doc.Add(new Paragraph($"Teléfono: {factura.Cliente.Telefono}"));
            doc.Add(new Paragraph($"Email: {factura.Cliente.Email}"));
            doc.Add(new Paragraph($"Capacidad mensual (kW): {factura.CapacidadMensualKw}"));
            doc.Add(new Paragraph($"Meses: {factura.MesesFuncionamiento}"));
            doc.Add(new Paragraph($"Consumo total (kW): {factura.ConsumoTotalKw}"));
            doc.Add(new Paragraph($"Monto total: {factura.MontoTotal:C2}"));
            doc.Add(new Paragraph($"Fecha: {factura.FechaCreacion}"));

            doc.Add(new Paragraph("Producción mensual: "));
            foreach (var p in factura.ProduccionMensual)
                doc.Add(new Paragraph($"- {p} kW"));

            doc.Close();
        }
    }
}
