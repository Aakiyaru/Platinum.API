using Knowtes.WebAPI.Commands;
using Platinum.WebAPI.Models;
using Platinum.WebAPI.Querries.Games;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Platinum.WebAPI.Commands.Games
{
    public class GetAllGamesCommand : Command
    {
        public List<Game> Execute()
        {
            GetAllGamesQuerry.Set();
            string commandText = Knowtes.WebAPI.Querries.Querry.GetText();

            List<Game> games = new List<Game>();

            Create(commandText);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                games.Add(new Game { Id = reader.GetInt32(5), Name = reader.GetString(0), Developer = reader.GetString(1), Publisher = reader.GetString(2), Realease = reader.GetString(3), Cover = reader.GetString(4) });
            }

            reader.Close();
            Dispose();

            return games;
        }
    }
}
