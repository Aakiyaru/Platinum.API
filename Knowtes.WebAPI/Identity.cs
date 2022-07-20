using System.Collections.Generic;
using System.Linq;
using Knowtes.Backend.Models;
using System.Security.Claims;
using Knowtes.WebAPI.Commands;

namespace CommonLibrary
{
    public static class Identity
    {
        private static AuthCommand command = new AuthCommand();

        public static ClaimsIdentity GetIdentity(string username, string password)
        {
            List<User> people = command.Execute(username, password);

            User user = people.FirstOrDefault(x => x.login == username && x.password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.login)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
