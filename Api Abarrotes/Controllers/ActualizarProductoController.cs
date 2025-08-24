using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api_Abarrotes.Controllers
{
    public class ActualizarProductoController : ApiController
    {

        [HttpPost]
        [Route("api/Producto/Actualizar")]
        public async Task<IHttpActionResult> Actualizar([FromBody] ML.Producto producto)
        {
            ML.Result result = await CQRS.Handlers.ActualizarProducto.Handle(producto);

            if (result.Correct)
                return Ok("Producto actualizado correctamente");
            else
                return BadRequest(result.ErrorMessage);
        }


    }
}
