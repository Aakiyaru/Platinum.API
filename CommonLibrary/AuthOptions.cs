using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Knowtes.WebAPI.AppData
{
    public class AuthOptions
    {
        ///Класс, содержащий в себе настройки создания JWT токена
        
        public const string Issuer = "MyAuthServer"; //издатель
        public const string Audience = "MyAuthClient"; //потребитель
        const string Key = "mysupersecret_secretkey!123"; //ключ для шифровки
        public const int Lifetime = 60; // время жизни токена в минутах

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
