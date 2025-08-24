using CQRS.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api_Abarrotes.Controllers
{
    public class GetAllProductoController : ApiController
    {
        [HttpGet]
        [Route("api/Producto/GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            ML.Result result = await CQRS.Handlers.GetAllProducto.Handle();

            if (result.Correct)
                return Ok(result.Objects);
            else
                return BadRequest(result.ErrorMessage);
        }


    }
}
