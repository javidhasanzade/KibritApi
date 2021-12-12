using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace KibritAPI.Options
{
    public class AuthOptions
    {
        public const string ISSUER = "Javid"; // издатель токена
        public const string AUDIENCE = "Javid"; // потребитель токена
        const string KEY = "fa887bb6-bc1f-41d8-9427-2d166f3f9886";   // ключ для шифрации
        public const int LIFETIME = 5; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}