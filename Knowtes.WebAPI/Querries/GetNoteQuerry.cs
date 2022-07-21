using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowtes.WebAPI.Querries
{
    public class GetNoteQuerry : Querry
    {
        public static void Set(string login, int id)
        {
            querryText = $"SELECT Id, Creator, Text, CreationDate FROM Notes WHERE Creator = '{login}' AND Id = {id}";
        }
    }
}
