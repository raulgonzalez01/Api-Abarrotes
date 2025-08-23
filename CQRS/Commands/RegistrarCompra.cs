using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public class RegistrarCompra
    {

        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }
        public int IdSucursal { get; set; }
        public int Cantidad { get; set; }


    }
}
