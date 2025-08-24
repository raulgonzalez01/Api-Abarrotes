using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Handlers
{
    public class ActualizarProducto
    {
        public static async Task<ML.Result> Handle(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {

                ML.Result Result = await BL.Usuario.GetById(producto.IdUsuario);

                if (!Result.Correct || Result.Object == null)
                {
                    result.Correct = false;
                    result.ErrorMessage = "Usuario no encontrado";
                    return result;
                }

                ML.Usuario usuario = (ML.Usuario)Result.Object;

                if (usuario.Rol.IdRol != 1)
                {
                    result.Correct = false;
                    result.ErrorMessage = "No tienes permisos para agregar productos";
                    return result;
                }


                using (DL.RetoTiendaEntities context = new DL.RetoTiendaEntities())
                {
                    var item = await Task.Run(() =>
                     context.ActualizarProductos (
                        producto.IdProducto,
                    producto.CodigoBarras,
                    producto.Nombre,
                    producto.Descripcion,
                    producto.Precio
                        )
                    );

                    result.Correct = item > 0;

                    if (!result.Correct)
                        result.ErrorMessage = "No se agregó ningún producto";
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
