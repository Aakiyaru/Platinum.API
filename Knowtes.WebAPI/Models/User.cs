namespace Knowtes.Backend.Models
{
    public class User : BaseModel
    {
        ///Класс, представляющий данные пользователя

        public string login { get; set; }
        public string password { get; set; }
        public string username { get; set; }
    }
}
