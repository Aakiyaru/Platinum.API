using System;
using Knowtes.WebAPI.Models;
using Knowtes.WebAPI.Querries;
using System.Data.SQLite;

namespace Knowtes.WebAPI.Commands
{
    public class GetNoteCommand : Command
    {
        public Note Execute(string login, int id)
        {
            GetNoteQuerry.Set(login, id);
            string commandText = GetAllNotesQuerry.GetText();

            Create(commandText);

            SQLiteDataReader reader = command.ExecuteReader();

            Note note = new Note();

            while (reader.Read())
            {
                note = new Note { Id = reader.GetInt32(0), Creator = reader.GetString(1), Text = reader.GetString(2), CreationDate = Convert.ToDateTime(reader.GetString(3)) };
            }

            reader.Close();
            Dispose();

            return note;
        }
    }
}
