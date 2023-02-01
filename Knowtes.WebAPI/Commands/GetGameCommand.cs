using Knowtes.WebAPI.Querries;
using System.Data.SQLite;
using Platinum.WebAPI.Models;

namespace Knowtes.WebAPI.Commands
{
    public class GetGameCommand : Command
    {
        public Game Execute(int id)
        {
            GetGameQuerry.Set(id);
            string commandText = GetGameQuerry.GetText();

            Create(commandText);

            SQLiteDataReader reader = command.ExecuteReader();

            Game game = new Game();

            while (reader.Read())
            {
                game = new Game { Id = reader.GetInt32(5), Name = reader.GetString(0), Developer = reader.GetString(1), Publisher = reader.GetString(2), Realease = reader.GetString(3), Cover = reader.GetString(4) };
            }

            reader.Close();
            Dispose();

            return game;
        }
    }
}
