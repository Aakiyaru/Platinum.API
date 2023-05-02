using Knowtes.WebAPI.Querries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Querries.Comments
{
    public class CreateCommentQuerry : Querry
    {
        public static void Set(long UserId, string Text, long AchivementId)
        {
            querryText = $"INSERT INTO Comments (UserId, Text, AchivementId) VALUES ('{UserId}','{Text}','{AchivementId}')";
        }
    }
}
