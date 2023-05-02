using System.Data.SqlClient;
using System.Data.SQLite;
using Knowtes.WebAPI.Commands;
using Platinum.WebAPI.Models;
using Platinum.WebAPI.Querries.Games;

namespace Platinum.WebAPI.Commands.Games
{
    public class GetGameCommand : Command
    {
        public GameInfo Execute(int id)
        {
            GetGameQuerry.Set(id);
            string commandText = Knowtes.WebAPI.Querries.Querry.GetText();

            Create(commandText);
            GameInfo game = new GameInfo();

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    game = new GameInfo { Id = reader.GetInt32(5), Name = reader.GetString(0), Developer = reader.GetString(1), Publisher = reader.GetString(2), Realease = reader.GetString(3), Cover = reader.GetString(4) };
                }

                reader.Close();
            }
            catch
            {
                Dispose();
            }
            
            Dispose();

            return game;
        }
    }
}
