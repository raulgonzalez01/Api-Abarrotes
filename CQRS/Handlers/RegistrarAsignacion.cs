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
                        result.ErrorMessage = "El usuario no existe.";
                        return result;
                    }

                    if (usuario.IdRol != 1) // 1 = Admin
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No tiene permisos para registrar compras. Solo administradores pueden realizar esta acción.";
                        return result;
                    }



                    int rowsAffected = await context.Database.ExecuteSqlCommandAsync(
                        "EXEC RegistrarCompraAsignacion @IdUsuario, @IdProducto, @IdSucursal, @Cantidad",
                        new SqlParameter("@IdUsuario", command.IdUsuario),
                        new SqlParameter("@IdProducto", command.IdProducto),
                        new SqlParameter("@IdSucursal", command.IdSucursal),
                        new SqlParameter("@Cantidad", command.Cantidad)
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
    }
}
