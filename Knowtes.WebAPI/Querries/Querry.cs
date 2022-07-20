namespace Knowtes.WebAPI.Querries
{
    public abstract class Querry
    {
        protected static string querryText;

        public static string GetText()
        {
            return querryText;
        }
    }
}
