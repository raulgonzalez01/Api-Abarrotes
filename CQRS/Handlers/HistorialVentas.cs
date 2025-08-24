using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Handlers
{
    public class HistorialVentas
    {
         public static async Task<ML.Result> Handle()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.RetoTiendaEntities context = new DL.RetoTiendaEntities())
                {
                    var query = await Task.Run(() => context.ConsultarHistorialVentas().ToList());

                    result.Objects = new List<object>();

                    foreach (var item in query)
                    {
                        var hist = new Commands.DetalleVenta
                        {
                            IdVenta = item.IdVenta,
                            NombreSucursal = item.NombreSucursal,
                            FechaYHora = (DateTime)item.FechaYHora,
                            Cantidad = (int)item.Cantidad,
                            Subtotal = (int)item.Subtotal
                        };
                        result.Objects.Add(hist);
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
