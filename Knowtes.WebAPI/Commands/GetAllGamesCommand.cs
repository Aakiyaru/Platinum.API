using Knowtes.WebAPI.Commands;
using Knowtes.WebAPI.Models;
using Platinum.WebAPI.Models;
using Platinum.WebAPI.Querries;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Commands
{
    public class GetAllGamesCommand : Command
    {
        public List<Game> Execute()
        {
            GetAllGamesQuerry.Set();
            string commandText = GetAllGamesQuerry.GetText();

            List<Game> games = new List<Game>();

            Create(commandText);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                games.Add(new Game {Name = reader.GetString(0), Developer = reader.GetString(1), Publisher = reader.GetString(2), Realease = reader.GetString(3), Cover = reader.GetString(4), Id = reader.GetInt32(5)});
            }

            reader.Close();
            Dispose();

            return games;
        }
    }
}
