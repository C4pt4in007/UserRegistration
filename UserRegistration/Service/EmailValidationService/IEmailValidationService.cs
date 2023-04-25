namespace UserRegistration.Service.EmailValidationService
{
    public interface IEmailValidationService
    {
        bool ValidateEmailFormat(string emailAddress);
    }
}
