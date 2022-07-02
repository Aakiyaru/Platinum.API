using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary;
using Knowtes.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Knowtes.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [Route("reg")]
        public IActionResult Reg([FromBody] User regData)
        {
            string name = regData.name;
            string login = regData.login;
            string email = regData.email;
            string password = Hash.GetHash(regData.password);

            return Ok(password);
        }

        [HttpGet]
        [Route("auth")]
        public IActionResult Auth([FromQuery] string login, [FromQuery] string password)
        {
            return Ok(new List<string> { login, password });
        }
    }
}
