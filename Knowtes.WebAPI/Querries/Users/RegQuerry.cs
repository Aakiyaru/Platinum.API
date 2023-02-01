using Knowtes.WebAPI.Querries;

namespace Platinum.WebAPI.Querries.Users
{
    public class RegQuerry : Querry
    {
        public static void Set(string login, string password, string username)
        {
            querryText = $"INSERT OR IGNORE INTO USERS (login, password, username) VALUES ('{login}', '{password}', '{username}')";
        }
    }
}
