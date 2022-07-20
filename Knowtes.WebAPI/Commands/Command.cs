using System;
using System.Data.SQLite;
using System.IO;

namespace Knowtes.WebAPI.Commands
{
    public abstract class Command
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"AppData\DataBase", "DataBase.db");
        private static SQLiteConnection connection = new SQLiteConnection($@"Data Source={filePath}; Version=3");
        private SQLiteCommand command;

        protected void Create(string commandText)
        {
            command = connection.CreateCommand();
            connection.Open();
            command.CommandText = commandText;
        }

        protected void Dispose()
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
        }
    }
}
