using CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Handlers
{
    public class RegistrarAsignacion
    {
        public static async Task<ML.Result> Handle(RegistrarCompra command)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.RetoTiendaEntities context = new DL.RetoTiendaEntities())
                {

                    var usuario = await context.Usuarios.FindAsync(command.IdUsuario);

                    if (usuario == null)
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El usuario no existe";
                        return result;
                    }

                    if (usuario.IdRol != 1) //  Admin
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No tiene permisos para registrar compras, solo los administradores pueden realizar esta acción";
                        return result;
                    }



                    var rowsAffected = await Task.Run(() =>
                       context.RegistrarCompraAsignacion(
                           command.IdUsuario,
                           command.IdProducto,
                           command.IdSucursal,
                           command.Cantidad
                       )
                   );

                    result.Correct = rowsAffected > 0;
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



        public static async Task<ML.Result> RegistrarVenta(RegistrarVenta command)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.RetoTiendaEntities context = new DL.RetoTiendaEntities())
                {
                    var usuario = await context.Usuarios.FindAsync(command.IdUsuario);

                    if (usuario == null)
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El usuario no existe";
                        return result;
                    }

                    if (usuario.IdRol != 1 && usuario.IdRol != 2) 
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No tiene permisos para registrar ventas";
                        return result;
                    }

                  
                    var ventaDetalles = new System.Data.DataTable();
                    ventaDetalles.Columns.Add("IdProducto", typeof(int));
                    ventaDetalles.Columns.Add("Cantidad", typeof(int));
                    ventaDetalles.Columns.Add("PrecioUnitario", typeof(decimal));

                    foreach (var detalle in command.Detalles)
                    {
                        ventaDetalles.Rows.Add(detalle.IdProducto, detalle.Cantidad, detalle.PrecioUnitario);
                    }

                   
                    var detallesParam = new System.Data.SqlClient.SqlParameter("@Detalles", ventaDetalles)
                    {
                        TypeName = "dbo.DetalleVentaType",  
                        SqlDbType = System.Data.SqlDbType.Structured
                    };

                    
                    var rowsAffected = await context.Database.ExecuteSqlCommandAsync(
                        "EXEC RegistrarVenta @IdSucursal, @Detalles",
                        new SqlParameter("@IdSucursal", command.IdSucursal),
                        detallesParam
                    );

                    result.Correct = rowsAffected > 0;

                    if (!result.Correct)
                        result.ErrorMessage = "No se pudo registrar la venta";
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
