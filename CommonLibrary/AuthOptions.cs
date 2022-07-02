using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Knowtes.WebAPI.AppData
{
    public class AuthOptions
    {
        ///Класс, содержащий в себе настройки создания JWT токена
        
        public const string ISSUER = "MyAuthServer"; //издатель
        public const string AUDIENCE = "MyAuthClient"; //потребитель
        const string KEY = "mysupersecret_secretkey!123"; //ключ для шифровки
        public const int LIFETIME = 5; // время жизни токена в минутах

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
