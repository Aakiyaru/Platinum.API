using Knowtes.WebAPI.Querries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Querries.Achivements
{
    public class GetAchivementQuerry : Querry
    {
        public static void Set(int id, int gameId)
        {
            querryText = $"SELECT Id, Name, Description, GameId, Icon FROM Achivements WHERE Id = {id} AND gameId = {gameId}";
        }
    }
}
