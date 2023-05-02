using Knowtes.WebAPI.Commands;
using Platinum.WebAPI.Models;
using Platinum.WebAPI.Querries.Games;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    games.Add(new Game { Id = reader.GetInt64(2), Name = reader.GetString(0), Cover = reader.GetString(1) });
                }

                reader.Close();
            }
            catch
            {
                Dispose();
            }
            
            Dispose();

            return games;
        }
    }
}
