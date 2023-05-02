using Knowtes.WebAPI.Commands;
using Platinum.WebAPI.Models;
using Platinum.WebAPI.Querries.Comments;
using Platinum.WebAPI.Querries.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Commands.Comments
{
    public class CreateCommentCommand : Command
    {
        public bool Execute(Comment comment)
        {
            CreateCommentQuerry.Set(comment.UserId, comment.Text, comment.AchivementId);
            string commandText = CreateCommentQuerry.GetText();

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

            if (check == 1)
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
