using System;
using Knowtes.WebAPI.Querries;

namespace Platinum.WebAPI.Querries.Games
{
    public class CreateGameQuerry : Querry
    {
        public static void Set(string name, string developer, string publisher, string Realease, string cover)
        {
            querryText = $"INSERT INTO Games (Name, Developer, Publisher, Realease, Cover) VALUES ('{name}','{developer}','{publisher}','{Realease}','{cover}')";
        }
    }
}
