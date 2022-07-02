namespace Knowtes.Backend.Models
{
    public class User : BaseModel
    {
        ///Класс, представляющий данные пользователя

        public string name { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
