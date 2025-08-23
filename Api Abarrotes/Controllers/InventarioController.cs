using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api_Abarrotes.Controllers
{
    public class InventarioController : ApiController
    {
        [HttpGet]
        [Route("api/Inventario/GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            ML.Result result = await CQRS.Handlers.InventarioHandlers.GetInventarioGeneral();

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }




    }
}
