using Knowtes.WebAPI.Querries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Querries.Games
{
    public class GetAllGamesQuerry : Querry
    {
        public static void Set()
        {
            querryText = $"SELECT Name, Cover, Id FROM Games;";
        }
    }
}
