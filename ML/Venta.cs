using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Venta
    {
        public int IdVentas { get; set; }
        public int IdSucursal { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total {  get; set; }

        public List<object> Ventas { get; set; }


    }
}
