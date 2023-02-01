using System.Collections.Generic;
using Knowtes.Backend.Models;
using System.Data.SQLite;
using Knowtes.WebAPI.Querries;

namespace Knowtes.WebAPI.Commands
{
    public class AuthCommand : Command
    {
        public List<User> Execute(string login, string password)
        {
            AuthQuerry.Set(login, password);
            string commandText = AuthQuerry.GetText();

            List<User> answer = new List<User>();

            Create(commandText);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                answer.Add(new User { login = reader.GetString(0), password = reader.GetString(1), username = reader.GetString(2), Id = reader.GetInt32(3) });
            }

            reader.Close();

            Dispose();

            return answer;
        }
    }
}
