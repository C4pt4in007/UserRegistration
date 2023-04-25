using Microsoft.Extensions.FileSystemGlobbing;
using System.Text.RegularExpressions;

namespace UserRegistration.Service.EmailValidationService
{
    public class EmailValidationService : IEmailValidationService
    {
        private string emailRegex = (@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
        public bool ValidateEmailFormat(string emailAddress) {
            
            Match matcher = Regex.Match(emailAddress, emailRegex, RegexOptions.IgnoreCase);

            if (matcher.Success) {
                return true;
            }

            return false;
        }
    }
}
