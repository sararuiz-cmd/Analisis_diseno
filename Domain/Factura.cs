using System;
using System.Collections.Generic;

namespace SencomFacturacion.Domain
{
    public class Factura
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public decimal CapacidadMensualKw { get; set; }
        public int MesesFuncionamiento { get; set; }
        public List<decimal> ProduccionMensual { get; set; } = new List<decimal>();
        public decimal ConsumoTotalKw { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
