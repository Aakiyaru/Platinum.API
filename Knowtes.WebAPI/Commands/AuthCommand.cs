using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            while(reader.Read())
            {
                answer.Add(new User { email = reader.GetString(0), login = reader.GetString(1), password = reader.GetString(2), name = reader.GetString(3), Id = reader.GetInt32(4) });
            }

            reader.Close();

            Dispose();

            return answer;
        }
    }
}
