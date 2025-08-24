using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public class DetalleVenta
    {
        public int IdVenta { get; set; }
        public string NombreSucursal { get; set; }
        public DateTime FechaYHora { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }


    }
}
