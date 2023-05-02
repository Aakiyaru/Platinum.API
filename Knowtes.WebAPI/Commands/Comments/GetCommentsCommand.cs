using Knowtes.WebAPI.Commands;
using Platinum.WebAPI.Models;
using Platinum.WebAPI.Querries.Comments;
using Platinum.WebAPI.Querries.Games;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Commands.Comments
{
    public class GetCommentsCommand : Command
    {
        public List<Comment> Execute(int AchivementId)
        {
            GetCommentsQuerry.Set(AchivementId);
            string commandText = Knowtes.WebAPI.Querries.Querry.GetText();

            List<Comment> comments = new List<Comment>();

            Create(commandText);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comments.Add(new Comment { Id = reader.GetInt32(0), UserId = reader.GetInt32(1), Text = reader.GetString(2)});
            }

            reader.Close();
            Dispose();

            return comments;
        }
    }
}
