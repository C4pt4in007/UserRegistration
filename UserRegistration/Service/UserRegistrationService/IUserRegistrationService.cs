using UserRegistration.Modal;

namespace UserRegistration.Service.UserRegistrationService
{
    public interface IUserRegistrationService
    {
        UserRegistrationResponseEntity RegisterUser(UserRegistrationRequestEntity userRegistrationRequestEntity);
    }
}
