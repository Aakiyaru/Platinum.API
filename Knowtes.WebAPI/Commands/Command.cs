using System.Data.SQLite;

namespace Knowtes.WebAPI.Commands
{
    public abstract class Command
    {
        protected static string filePath = @"..\Knowtes.WebAPI\AppData\DataBase\DataBase.db";
        protected static SQLiteConnection connection = new SQLiteConnection($@"Data Source={filePath}; Version=3");
        protected static SQLiteCommand command;

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
