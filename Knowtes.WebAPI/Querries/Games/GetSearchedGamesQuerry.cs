using Knowtes.WebAPI.Querries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Querries.Games
{
    public class GetSearchedGamesQuerry : Querry
    {
        public static void Set(string searchString)
        {
            querryText = $"SELECT Name, Cover, Id FROM Games WHERE name LIKE '%{searchString}%';";
        }
    }
}
