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
        public static void Set(int UserId, string Text, int AchivementId)
        {
            querryText = $"INSERT INTO Comments (UserId, Text, AchivementId) VALUES ('{UserId}','{Text}','{AchivementId}')";
        }
    }
}
