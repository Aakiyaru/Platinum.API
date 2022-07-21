using System;

namespace Knowtes.WebAPI.Querries
{
    public class CreateNoteQuerry : Querry
    {
        public static void Set(string creator, string text, DateTime creationDate)
        {
            querryText = $"INSERT INTO Notes (Creator, Text, CreationDate) VALUES ('{creator}','{text}','{creationDate}')";
        }
    }
}
