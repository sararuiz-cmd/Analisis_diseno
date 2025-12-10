using SencomFacturacion.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SencomFacturacion.Services
{
    public class FacturaService
    {
        private readonly string _filePath;
        private const decimal PrecioKw = 0.13m;

        public FacturaService()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "facturas.txt");
            if (!File.Exists(_filePath))
                File.Create(_filePath).Close();
        }

        public List<Factura> ObtenerFacturas()
        {
            var lista = new List<Factura>();
            foreach (var linea in File.ReadAllLines(_filePath))
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;
                var p = linea.Split('|');
                if (p.Length < 11) continue;

                var fac = new Factura
                {
                    Id = int.Parse(p[0]),
                    Cliente = new Cliente
                    {
                        Nombre = p[1],
                        Direccion = p[2],
                        Telefono = p[3],
                        Email = p[4]
                    },
                    CapacidadMensualKw = decimal.Parse(p[5]),
                    MesesFuncionamiento = int.Parse(p[6]),
                    ProduccionMensual = p[7].Split(',').Select(x => decimal.Parse(x)).ToList(),
                    ConsumoTotalKw = decimal.Parse(p[8]),
                    MontoTotal = decimal.Parse(p[9]),
                    FechaCreacion = DateTime.Parse(p[10])
                };

                lista.Add(fac);
            }
            return lista;
        }

        public Factura CrearFactura(Factura factura)
        {
            var facs = ObtenerFacturas();
            factura.Id = facs.Any() ? facs.Max(f => f.Id) + 1 : 1;

            factura.ConsumoTotalKw = factura.ProduccionMensual.Sum();
            factura.MontoTotal = factura.ConsumoTotalKw * PrecioKw;

            Guardar(factura);
            return factura;
        }

        public void ActualizarFactura(Factura factura)
        {
            var lista = ObtenerFacturas();
            var index = lista.FindIndex(f => f.Id == factura.Id);
            if (index >= 0)
            {
                lista[index] = factura;
                Reescribir(lista);
            }
        }

        public void EliminarFactura(int id)
        {
            var lista = ObtenerFacturas();
            lista.RemoveAll(f => f.Id == id);
            Reescribir(lista);
        }

        private void Guardar(Factura f)
        {
            string linea = string.Join("|",
                f.Id, f.Cliente.Nombre, f.Cliente.Direccion, f.Cliente.Telefono, f.Cliente.Email,
                f.CapacidadMensualKw, f.MesesFuncionamiento,
                string.Join(",", f.ProduccionMensual),
                f.ConsumoTotalKw, f.MontoTotal, f.FechaCreacion);

            File.AppendAllLines(_filePath, new[] { linea });
        }

        private void Reescribir(List<Factura> lista)
        {
            var lineas = new List<string>();
            foreach (var f in lista)
            {
                string linea = string.Join("|",
                    f.Id, f.Cliente.Nombre, f.Cliente.Direccion, f.Cliente.Telefono, f.Cliente.Email,
                    f.CapacidadMensualKw, f.MesesFuncionamiento,
                    string.Join(",", f.ProduccionMensual),
                    f.ConsumoTotalKw, f.MontoTotal, f.FechaCreacion);
                lineas.Add(linea);
            }
            File.WriteAllLines(_filePath, lineas);
        }
    }
}
