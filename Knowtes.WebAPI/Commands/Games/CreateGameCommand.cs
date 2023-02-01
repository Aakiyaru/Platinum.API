using Knowtes.WebAPI.Commands;
using Knowtes.WebAPI.Querries;
using Platinum.WebAPI.Models;
using Platinum.WebAPI.Querries.Games;

namespace Platinum.WebAPI.Commands.Games
{
    public class CreateGameCommand : Command
    {
        public bool Execute(Game game)
        {
            CreateGameQuerry.Set(game.Name, game.Developer, game.Publisher, game.Realease, game.Cover);
            string commandText = CreateGameQuerry.GetText();

            Create(commandText);

            int check = command.ExecuteNonQuery();

            Dispose();

            if (check == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
