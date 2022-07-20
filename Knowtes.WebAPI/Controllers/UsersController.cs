using CommonLibrary;
using Knowtes.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Knowtes.WebAPI.AppData;

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

        [HttpPost]
        [Route("auth")]
        public IActionResult Token([FromQuery] string username, [FromQuery] string password)
        {
            var identity = Identity.GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
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
