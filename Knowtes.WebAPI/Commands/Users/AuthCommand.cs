using System.Collections.Generic;
using Knowtes.Backend.Models;
using System.Data.SQLite;
using Knowtes.WebAPI.Querries;
using Knowtes.WebAPI.Commands;
using Platinum.WebAPI.Querries.Users;
using System.Data.SqlClient;

namespace Platinum.WebAPI.Commands.Users
{
    public class AuthCommand : Command
    {
        public List<User> Execute(string login, string password)
        {
            AuthQuerry.Set(login, password);
            string commandText = AuthQuerry.GetText();

            List<User> answer = new List<User>();

            Create(commandText);

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    answer.Add(new User { login = reader.GetString(0), password = reader.GetString(1), username = reader.GetString(2), Id = reader.GetInt32(3) });
                }

                reader.Close();
            }
            catch
            {
                Dispose();
            }

            Dispose();

            return answer;
        }
    }
}
