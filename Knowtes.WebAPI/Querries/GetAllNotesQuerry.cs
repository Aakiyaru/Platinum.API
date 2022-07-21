namespace Knowtes.WebAPI.Querries
{
    public class GetAllNotesQuerry : Querry
    {
        public static void Set(string login)
        {
            querryText = $"SELECT Id, Creator, Text, CreationDate FROM Notes WHERE Creator = '{login}'";
        }
    }
}
