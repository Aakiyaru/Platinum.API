using Knowtes.WebAPI.Models;
using Knowtes.WebAPI.Querries;

namespace Knowtes.WebAPI.Commands
{
    public class CreateNoteCommand : Command
    {
        public bool Execute(Note note)
        {
            CreateNoteQuerry.Set(note.Creator, note.Text, note.CreationDate);
            string commandText = CreateNoteQuerry.GetText();

            Create(commandText);

            int check = command.ExecuteNonQuery();

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
