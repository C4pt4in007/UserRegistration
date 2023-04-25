using Org.BouncyCastle.Utilities.Encoders;

namespace UserRegistration.Service.PasswordEncryptorService
{
    public class PasswordEncryptorService
    {
        public static string EncryptPassword(string userPassword) 
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(userPassword));
        }
    }
}
