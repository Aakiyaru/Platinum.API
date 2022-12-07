using CommonLibrary;
using Knowtes.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Knowtes.WebAPI.AppData;
using Knowtes.WebAPI.Commands;

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
            regData.password = Hash.GetHash(regData.password);

            RegCommand command = new RegCommand();

            if (command.Execute(regData))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("auth")]
        public IActionResult Token([FromQuery] string username, [FromQuery] string password)
        {
            var identity = Identity.GetIdentity(username, Hash.GetHash(password));
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Ok(response);
        }
    }
}
