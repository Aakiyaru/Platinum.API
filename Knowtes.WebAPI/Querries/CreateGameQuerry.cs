using System;

namespace Knowtes.WebAPI.Querries
{
    public class CreateGameQuerry : Querry
    {
        public static void Set(string name, string developer, string publisher, string Realease, string cover)
        {
            querryText = $"INSERT INTO Games (Name, Developer, Publisher, Realease, Cover) VALUES ('{name}','{developer}','{publisher}','{Realease}','{cover}')";
        }
    }
}
