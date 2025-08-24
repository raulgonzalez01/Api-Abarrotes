using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {

        public static async Task<ML.Result> GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.RetoTiendaEntities context = new DL.RetoTiendaEntities())
                {
                    var query = await Task.Run(() =>
                        context.GetById(idUsuario).FirstOrDefault()
                    );

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario
                        {
                            IdUsuario = query.IdUsuario,
                            Nombre = query.Nombre,
                            UsuarioLogin = query.UsuarioLogin,
                            IdSucursal = (int)query.IdSucursal,
                            Rol = new ML.Rol
                            {
                                IdRol = (int)query.IdRol,
                               
                            }
                        };

                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el usuario";
                    }
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
