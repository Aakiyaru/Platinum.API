using Knowtes.WebAPI.Commands;
using Knowtes.WebAPI.Querries;
using Platinum.WebAPI.Models;
using Platinum.WebAPI.Querries.Games;

namespace Platinum.WebAPI.Commands.Games
{
    public class CreateGameCommand : Command
    {
        public bool Execute(GameInfo game)
        {
            CreateGameQuerry.Set(game.Name, game.Developer, game.Publisher, game.Realease, game.Cover);
            string commandText = CreateGameQuerry.GetText();

            Create(commandText);
            int check = 0;

            try
            {
                check = command.ExecuteNonQuery();
            }
            catch
            {
                Dispose();
            }
            
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
