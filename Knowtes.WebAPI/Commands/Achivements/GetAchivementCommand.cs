using Knowtes.WebAPI.Commands;
using Platinum.WebAPI.Models;
using Platinum.WebAPI.Querries.Achivements;
using Platinum.WebAPI.Querries.Games;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Commands.Achivements
{
    public class GetAchivementCommand : Command
    {
        public Achivement Execute(int id, int gameId)
        {
            GetAchivementQuerry.Set(id, gameId);
            string commandText = Knowtes.WebAPI.Querries.Querry.GetText();

            Create(commandText);

            Achivement achivement = new Achivement();

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    achivement = new Achivement { Id = reader.GetInt32(0), Name = reader.GetString(1), Description = reader.GetString(2), GameId = reader.GetInt32(3), Icon = reader.GetString(4) };
                }

                reader.Close();
                Dispose();
            }
            catch
            {
                Dispose();
            }
            

            return achivement;
        }
    }
}
