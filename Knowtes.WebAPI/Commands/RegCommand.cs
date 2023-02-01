using Knowtes.Backend.Models;
using Knowtes.WebAPI.Querries;

namespace Knowtes.WebAPI.Commands
{
    public class RegCommand : Command
    {
        public bool Execute(User regData)
        {
            RegQuerry.Set(regData.login, regData.password, regData.username);
            string commandText = RegQuerry.GetText();

            Create(commandText);

            int check = command.ExecuteNonQuery();

            Dispose();

            if (check != 0)
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
