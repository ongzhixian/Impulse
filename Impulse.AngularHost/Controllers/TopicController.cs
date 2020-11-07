using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace Impulse.AngularHost.Controllers
{
    [Route("api/[controller]")]
    public class TestTextController : Controller
    {
        [HttpGet("SomeText")]
        public ActionResult GetSomeText()
        {
            return Ok(new {
                Message = "Some text message"
            });
        }

        [HttpGet("SecretText")]
        [Authorize]
        public ActionResult GetSecretText()
        {
            return Ok(new {
                Message = "Some secret text"
            });
        }
    }
}
