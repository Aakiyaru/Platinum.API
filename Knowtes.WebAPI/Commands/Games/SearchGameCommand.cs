using Knowtes.WebAPI.Commands;
using Platinum.WebAPI.Models;
using Platinum.WebAPI.Querries.Games;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Commands.Games
{
    public class SearchGameCommand : Command
    {
        public List<Game> Execute(string searchString)
        {
            GetSearchedGamesQuerry.Set(searchString);
            string commandText = Knowtes.WebAPI.Querries.Querry.GetText();

            List<Game> games = new List<Game>();

            Create(commandText);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                games.Add(new Game { Id = reader.GetInt32(2), Name = reader.GetString(0), Cover = reader.GetString(1) });
            }

            reader.Close();
            Dispose();

            return games;
        }
    }
}
