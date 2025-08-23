using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class DetallesVentas
    {
        public int IdDetalle {  get; set; }

        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }


        public List<object> Detalles { get; set; }
    }
}
