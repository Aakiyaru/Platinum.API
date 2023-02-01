namespace Knowtes.WebAPI.Querries
{
    public class AuthQuerry : Querry
    {
        public static void Set(string login, string password)
        {
            querryText = $"SELECT login, password, username, id FROM USERS WHERE Login = '{login}' AND Password = '{password}'";
        }
    }
}
