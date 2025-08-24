using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api_Abarrotes.Controllers
{
    public class AgregarProductoController : ApiController
    {

        [HttpPost]
        [Route("api/Producto/Agregar")]
        public async Task<IHttpActionResult> Agregar([FromBody] ML.Producto producto)
        {
            ML.Result result = await CQRS.Handlers.AgregarProducto.Handle(producto);

            if (result.Correct)
                return Ok("Producto agregado correctamente");
            else
                return BadRequest(result.ErrorMessage);
        }

    }
}
