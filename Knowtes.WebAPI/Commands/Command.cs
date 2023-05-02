using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Knowtes.WebAPI.Commands
{
    public abstract class Command
    {
        protected static SqlConnection connection = new SqlConnection("Data Source=SQL6029.site4now.net;Initial Catalog=db_a9882b_database;User Id=db_a9882b_database_admin;Password=qweasd123");
        protected static SqlCommand command;

        protected void Create(string commandText)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = commandText;
        }

        protected void Dispose()
        {
            command.Dispose();
            connection.Close();
        }
    }
}
