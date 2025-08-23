using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Compras
    {
        public int IdCompra {  get; set; }

        public int IdProducto { get; set; }
        public int IdSucursal { get; set; }

        public int Cantidad { get; set; }

        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }

    }
}
