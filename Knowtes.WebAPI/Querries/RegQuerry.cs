namespace Knowtes.WebAPI.Querries
{
    public class RegQuerry : Querry
    {
        public static void Set(string name, string login, string password, string email)
        {
            querryText = $"INSERT OR IGNORE INTO USERS (name, login, password, email) VALUES ('{name}', '{login}', '{password}', '{email}')";
        }
    }
}
