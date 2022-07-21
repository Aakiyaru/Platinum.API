using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knowtes.WebAPI.Models;
using Knowtes.WebAPI.Querries;

namespace Knowtes.WebAPI.Commands
{
    public class GetAllNotesCommand : Command
    {
        public List<Note> Execute(string login)
        {
            GetAllNotesQuerry.Set(login);
            string commandText = GetAllNotesQuerry.GetText();

            List<Note> notes = new List<Note>();

            Create(commandText);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                notes.Add(new Note { Id = reader.GetInt32(0), Creator = reader.GetString(1), Text = reader.GetString(2), CreationDate = reader.GetDateTime(3) });
            }

            reader.Close();
            Dispose();

            return notes;
        }
    }
}
