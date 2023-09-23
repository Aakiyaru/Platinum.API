//using CommonLibrary;
//using Knowtes.Backend.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using Knowtes.WebAPI.AppData;
//using System.Data.SqlClient;
//using System.Collections.Generic;
//using static Knowtes.Backend.Controllers.RegCommand;

//namespace Knowtes.Backend.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class UsersController : ControllerBase
//    {
//        [HttpPost]
//        [Route("reg")]
//        public IActionResult Reg([FromBody] User regData)
//        {
//            regData.password = Hash.GetHash(regData.password);

//            RegCommand command = new RegCommand();

//            if (command.Execute(regData))
//            {
//                return Ok();
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }

//        [HttpPost]
//        [Route("auth")]
//        public IActionResult Token([FromQuery] string login, [FromQuery] string password)
//        {
//            var identity = Identity.GetIdentity(login, Hash.GetHash(password));
//            if (identity == null)
//            {
//                return BadRequest(new { errorText = "Invalid login or password." });
//            }

//            var now = DateTime.UtcNow;
//            // создаем JWT-токен
//            var jwt = new JwtSecurityToken(
//                    issuer: AuthOptions.Issuer,
//                    audience: AuthOptions.Audience,
//                    notBefore: now,
//                    claims: identity.Claims,
//                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
//                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
//            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

//            var response = new
//            {
//                access_token = encodedJwt,
//                username = identity.Name
//            };

//            return Ok(response);
//        }
//    }

//    public abstract class Command
//    {
//        protected static SqlConnection connection = new SqlConnection("Data Source=SQL6030.site4now.net;Initial Catalog=db_a9882b_database;User Id=db_a9882b_database_admin;Password=qweasd123");
//        protected static SqlCommand command;

//        protected void Create(string commandText)
//        {
//            connection.Open();
//            command = connection.CreateCommand();
//            command.CommandText = commandText;
//        }

//        protected void Dispose()
//        {
//            command.Dispose();
//            connection.Close();
//            connection.Dispose();
//        }
//    }

//    public class AuthCommand : Command
//    {
//        public List<User> Execute(string login, string password)
//        {
//            AuthQuerry.Set(login, password);
//            string commandText = AuthQuerry.GetText();

//            List<User> answer = new List<User>();

//            Create(commandText);

//            try
//            {
//                SqlDataReader reader = command.ExecuteReader();

//                while (reader.Read())
//                {
//                    answer.Add(new User { login = reader.GetString(0), password = reader.GetString(1), username = reader.GetString(2), Id = reader.GetInt32(3) });
//                }

//                reader.Close();
//            }
//            catch
//            {
//                Dispose();
//            }

//            Dispose();

//            return answer;
//        }
//    }

//    public class RegCommand : Command
//    {
//        public bool Execute(User regData)
//        {
//            RegQuerry.Set(regData.login, regData.password, regData.username);
//            string commandText = Querry.GetText();

//            Create(commandText);
//            int check = 0;

//            try
//            {
//                check = command.ExecuteNonQuery();
//            }
//            catch
//            {
//                Dispose();
//            }

//            Dispose();

//            if (check != 0)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        public abstract class Querry
//        {
//            protected static string querryText;

//            public static string GetText()
//            {
//                return querryText;
//            }
//        }

//        public class AuthQuerry : Querry
//        {
//            public static void Set(string login, string password)
//            {
//                querryText = $"SELECT login, password, username, id FROM USERS WHERE Login = '{login}' AND Password = '{password}'";
//            }
//        }

//        public class RegQuerry : Querry
//        {
//            public static void Set(string login, string password, string username)
//            {
//                querryText = $"INSERT OR IGNORE INTO USERS (login, password, username) VALUES ('{login}', '{password}', '{username}')";
//            }
//        }
//    }
//}
