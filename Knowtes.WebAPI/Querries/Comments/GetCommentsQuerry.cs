using Knowtes.WebAPI.Querries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Querries.Comments
{
    public class GetCommentsQuerry : Querry
    {
        public static void Set(int AchivementId)
        {
            querryText = $"SELECT Id, UserId, Text FROM Comments WHERE AchivementId = {AchivementId}";
        }
    }
}
