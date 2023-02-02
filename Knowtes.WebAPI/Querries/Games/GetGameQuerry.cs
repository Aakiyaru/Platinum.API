using Knowtes.WebAPI.Querries;

namespace Platinum.WebAPI.Querries.Games
{
    public class GetGameQuerry : Querry
    {
        public static void Set(int id)
        {
            querryText = $"SELECT Name, Developer, Publisher, Realease, Cover, Id FROM Games WHERE Id = {id}";
        }
    }
}
