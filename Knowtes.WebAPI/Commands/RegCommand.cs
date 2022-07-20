using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knowtes.Backend.Models;
using System.Data.SQLite;
using Knowtes.WebAPI.Querries;

namespace Knowtes.WebAPI.Commands
{
    public class RegCommand : Command
    {
        public bool Execute(User regData)
        {
            RegQuerry.Set(regData.name, regData.login, regData.password, regData.email);
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
