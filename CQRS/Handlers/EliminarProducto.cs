using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Handlers
{
    public class EliminarProducto
    {
        public static async Task<ML.Result> HandleEliminar(int idProducto, int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
              
                ML.Result Result = await BL.Usuario.GetById(idUsuario);

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
                    result.ErrorMessage = "No tienes permisos para eliminar productos";
                    return result;
                }

                using (DL.RetoTiendaEntities context = new DL.RetoTiendaEntities())
                {
                  
                    var rowsAffected = await Task.Run(() => context.EliminarProducto(idProducto));

                    result.Correct = rowsAffected > 0;

                    if (!result.Correct)
                        result.ErrorMessage = "No se eliminó ningún producto";
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
