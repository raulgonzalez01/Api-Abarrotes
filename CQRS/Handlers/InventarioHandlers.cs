using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Handlers
{
    public class InventarioHandlers
    {
        public static async Task<ML.Result> GetInventarioGeneral()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.RetoTiendaEntities context = new DL.RetoTiendaEntities())
                {
                    
                    var query = await Task.Run(() => context.InventarioGeneral().ToList());

                    List<object> inventarios = new List<object>();

                    foreach (var item in query)
                    {
                        ML.Inventario inventario = new ML.Inventario()
                        {
                            IdProducto = item.IdProducto,
                            IdSucursal = item.IdSucursal,
                            Stock = (int)item.Stock,

                            Producto = new ML.Producto()
                            {
                                IdProducto = item.IdProducto,
                                CodigoBarras = item.CodigoBarras,
                                Nombre = item.NombreProducto,
                                Descripcion = item.Descripcion,
                                Precio = item.Precio.HasValue ? item.Precio.Value : 0
                            },
                            sucursal = new ML.Sucursal()
                            {
                                IdSucursal = item.IdSucursal,
                                Nombre = item.NombreSucursal,
                                Direccion = item.Direccion
                            }
                        };

                        inventarios.Add(inventario);
                    }

                    result.Objects = inventarios;
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


        public static async Task<ML.Result> GetInventarioPorSucursal(int idSucursal)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.RetoTiendaEntities context = new DL.RetoTiendaEntities())
                {

                    var sucursalExiste = context.Sucursales.Any(s => s.IdSucursal == idSucursal);

                    if (!sucursalExiste)
                    {
                        result.Correct = false;
                        result.ErrorMessage = $"La sucursal con Id {idSucursal} no existe.";
                        return result;
                    }



                    var query = await Task.Run(() =>
                        context.InventarioGeneral()
                        .Where(i => i.IdSucursal == idSucursal)
                        .ToList()
                    );

                    List<object> inventarios = new List<object>();

                    foreach (var item in query)
                    {
                        ML.Inventario inventario = new ML.Inventario()
                        {
                            IdProducto = item.IdProducto,
                            IdSucursal = item.IdSucursal,
                            Stock = (int)item.Stock,

                            Producto = new ML.Producto()
                            {
                                IdProducto = item.IdProducto,
                                CodigoBarras = item.CodigoBarras,
                                Nombre = item.NombreProducto,
                                Descripcion = item.Descripcion,
                                Precio = item.Precio.HasValue ? item.Precio.Value : 0
                            },
                            sucursal = new ML.Sucursal()
                            {
                                IdSucursal = item.IdSucursal,
                                Nombre = item.NombreSucursal,
                                Direccion = item.Direccion
                            }
                        };

                        inventarios.Add(inventario);
                    }

                    result.Objects = inventarios;
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
