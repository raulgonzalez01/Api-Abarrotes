using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Handlers
{
    public class GetAllProducto
    {
        public static async Task<ML.Result> Handle()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.RetoTiendaEntities context = new DL.RetoTiendaEntities())
                {
                    var query = await Task.Run(() => context.GetAllProductos().ToList());

                    result.Objects = new List<object>();

                    foreach (var item in query)
                    {
                        ML.Producto producto = new ML.Producto
                        {
                            IdProducto = item.IdProducto,
                            CodigoBarras = item.CodigoBarras,
                            Nombre = item.Nombre,
                            Descripcion = item.Descripcion,
                            Precio = (decimal)item.Precio
                        };

                        result.Objects.Add(producto);
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }



    }
}
