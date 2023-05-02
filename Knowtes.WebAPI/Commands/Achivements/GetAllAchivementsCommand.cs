using Knowtes.WebAPI.Commands;
using Platinum.WebAPI.Models;
using Platinum.WebAPI.Querries.Achivements;
using Platinum.WebAPI.Querries.Games;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Commands.Achivements
{
    public class GetAllAchivementsCommand : Command
    {
        public List<Achivement> Execute(int gameId)
        {
            GetAllAchivementsQuerry.Set(gameId);
            string commandText = Knowtes.WebAPI.Querries.Querry.GetText();

            List<Achivement> achivements = new List<Achivement>();

            Create(commandText);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                achivements.Add(new Achivement { Id = reader.GetInt64(0), Name = reader.GetString(1), Description = reader.GetString(2), GameId = reader.GetInt64(3), Icon = reader.GetString(4) });
            }

            reader.Close();
            Dispose();

            return achivements;
        }
    }
}
