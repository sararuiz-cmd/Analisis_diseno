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

            if (!File.Exists(_filePath))
                return lista;

            var lineas = File.ReadAllLines(_filePath);

            foreach (var linea in lineas)
            {
                if (string.IsNullOrWhiteSpace(linea))
                    continue;

                var p = linea.Split('|');

                try
                {
                    if (p.Length == 9)
                    {
                        // Formato viejo:
                        // 0=id |1=nombre |2=dir |3=cap |4=meses |5=producciones |6=consumo |7=monto |8=fecha

                        var factura = new Factura
                        {
                            Id = int.Parse(p[0]),
                            Cliente = new Cliente
                            {
                                Nombre = p[1],
                                Direccion = p[2],
                                Telefono = "",   // vacío
                                Email = ""       // vacío
                            },
                            CapacidadMensualKw = decimal.Parse(p[3]),
                            MesesFuncionamiento = int.Parse(p[4]),
                            ProduccionMensual = p[5].Split(',')
                                .Where(x => !string.IsNullOrWhiteSpace(x))
                                .Select(x => decimal.Parse(x))
                                .ToList(),
                            ConsumoTotalKw = decimal.Parse(p[6]),
                            MontoTotal = decimal.Parse(p[7]),
                            FechaCreacion = DateTime.Parse(p[8])
                        };

                        lista.Add(factura);
                    }
                    else if (p.Length >= 11)
                    {
                        // Formato nuevo:
                        // 0=id |1=nombre |2=dir |3=tel |4=email |5=cap |6=meses |7=producciones |8=consumo |9=monto |10=fecha

                        var factura = new Factura
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
                            ProduccionMensual = p[7].Split(',')
                                .Where(x => !string.IsNullOrWhiteSpace(x))
                                .Select(x => decimal.Parse(x))
                                .ToList(),
                            ConsumoTotalKw = decimal.Parse(p[8]),
                            MontoTotal = decimal.Parse(p[9]),
                            FechaCreacion = DateTime.Parse(p[10])
                        };

                        lista.Add(factura);
                    }
                    // si no es ni 9 ni 11 campos, ignoramos la línea
                }
                catch
                {
                    // Si una línea está dañada, la saltamos para no romper todo
                    continue;
                }
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
