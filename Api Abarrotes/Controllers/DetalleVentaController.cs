using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api_Abarrotes.Controllers
{
    public class DetalleVentaController : ApiController
    {

        [HttpGet]
        [Route("api/Ventas/Historial")]
        public async Task<IHttpActionResult> Historial()
        {
            ML.Result result = await CQRS.Handlers.HistorialVentas.Handle();

            if (result.Correct)
                return Ok(result.Objects);
            else
                return BadRequest(result.ErrorMessage);
        }
    }
}
