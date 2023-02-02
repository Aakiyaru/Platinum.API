using Knowtes.WebAPI.Querries;

namespace Platinum.WebAPI.Querries.Users
{
    public class AuthQuerry : Querry
    {
        public static void Set(string login, string password)
        {
            querryText = $"SELECT login, password, username, id FROM USERS WHERE Login = '{login}' AND Password = '{password}'";
        }
    }
}
