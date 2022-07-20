using System.Collections.Generic;
using System.Linq;
using Knowtes.Backend.Models;
using System.Security.Claims;

namespace CommonLibrary
{
    public static class Identity
    {
        // тестовые данные вместо использования базы данных
        private static List<User> people = new List<User>
        {
            new User {email = "JellyBall@mail.ru", login = "eruwe", password = "qweasd123", name = "denis", Id = 1}
        };

        public static ClaimsIdentity GetIdentity(string username, string password)
        {
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
