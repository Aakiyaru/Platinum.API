using Knowtes.WebAPI.Querries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Querries.Achivements
{
    public class GetAllAchivementsQuerry : Querry
    {
        public static void Set(int gameId)
        {
            querryText = $"SELECT Id, Name, Description, GameId, Icon FROM Achivements WHERE GameId = {gameId};";
        }
    }
}

