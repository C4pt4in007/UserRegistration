using UserRegistration.Modal;

namespace UserRegistration.Repositiory.AddUserRepository
{
    public interface IAddUserRepository
    {
        bool AddUserToDb(UserRegistrationRequestEntity userRegistrationRequestEntity);
    }
}
