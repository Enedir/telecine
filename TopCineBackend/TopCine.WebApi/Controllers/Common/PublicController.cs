using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TopCine.WebApi.Controllers.Common
{
    [Route("api/")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        [HttpGet]
        [Route("is-alive")]
        public ActionResult<bool> IsAlive()
        {
            return Ok(true);
        }
    }
}