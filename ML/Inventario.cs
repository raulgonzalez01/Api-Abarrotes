using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Inventario
    {
        
        public int IdInventario { get; set; }

        public int IdProducto { get; set; }
        public int IdSucursal { get; set; }

        public int Stock { get; set; }


        //public List<object> Inventarios { get; set; }

        public ML.Producto Producto { get; set; }

        public ML.Sucursal sucursal { get; set; }

    }
}
