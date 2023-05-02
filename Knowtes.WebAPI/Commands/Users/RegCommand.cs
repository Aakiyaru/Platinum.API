using Knowtes.Backend.Models;
using Knowtes.WebAPI.Commands;
using Platinum.WebAPI.Querries.Users;

namespace Platinum.WebAPI.Commands.Users
{
    public class RegCommand : Command
    {
        public bool Execute(User regData)
        {
            RegQuerry.Set(regData.login, regData.password, regData.username);
            string commandText = Knowtes.WebAPI.Querries.Querry.GetText();

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
