using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSIRIS.Api.Filters;

namespace OSIRIS.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class TestController : ControllerBase
    {
        [HttpGet("secret")]
        public IActionResult GetSecret()
        {
            return Ok("I have no secrets");
        }
    }
}