using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api_Abarrotes.Controllers
{
    public class EliminarProductoController : ApiController
    {


        [HttpDelete]
        [Route("api/Producto/Eliminar")]
        public async Task<IHttpActionResult> Eliminar([FromUri] int idProducto, [FromUri] int idUsuario)
        {
            ML.Result result = await CQRS.Handlers.EliminarProducto.HandleEliminar(idProducto, idUsuario);

            if (result.Correct)
                return Ok("Producto eliminado correctamente");
            else
                return BadRequest(result.ErrorMessage);
        }
    }
}
