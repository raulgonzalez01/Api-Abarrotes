using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public class RegistrarVenta
    {
        public int IdUsuario { get; set; }
        public int IdSucursal { get; set; }

        public List<DetalleVenta> Detalles { get; set; }

        public class DetalleVenta
        {
            public int IdProducto { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
        }
    }
}
