namespace Knowtes.WebAPI.Querries
{
    public class GetGameQuerry : Querry
    {
        public static void Set(int id)
        {
            querryText = $"SELECT Name, Developer, Publisher, Realese, Cover, Id FROM Games WHERE Id = {id}";
        }
    }
}
