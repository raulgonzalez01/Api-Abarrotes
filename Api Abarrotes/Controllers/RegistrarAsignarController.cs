using CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api_Abarrotes.Controllers
{
    public class RegistrarAsignarController : ApiController
    {
        [HttpPost]
        [Route("api/Compra/Registrar")]
        public async Task<IHttpActionResult> Registrar([FromBody] RegistrarCompra command)
        {
            ML.Result result = await CQRS.Handlers.RegistrarAsignacion.Handle(command);

            if (result.Correct)
                return Ok("Compra registrada y producto asignado correctamente");
            else
                return BadRequest(result.ErrorMessage);
        }



        [HttpPost]
        [Route("api/Venta/Registrar")]
        public async Task<IHttpActionResult> Registrar([FromBody] CQRS.Commands.RegistrarVenta command)
        {
            ML.Result result = await CQRS.Handlers.RegistrarAsignacion.RegistrarVenta(command);

            if (result.Correct)
                return Ok("Venta registrada correctamente");
            else
                return BadRequest(result.ErrorMessage);
        }



    }
}
