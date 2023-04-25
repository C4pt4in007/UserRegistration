using UserRegistration.Modal;
using UserRegistration.Repositiory.AddUserRepository;
using UserRegistration.Service.CheckUserService;
using UserRegistration.Service.EmailValidationService;

namespace UserRegistration.Service.UserRegistrationService
{
    public class UserRegistrationService : IUserRegistrationService
    {

        private IEmailValidationService emailValidationService;
        private ICheckUserService checkUserService;
        private IAddUserRepository addUserRepository;
        public UserRegistrationService(IEmailValidationService emailValidationService, ICheckUserService checkUserService, IAddUserRepository addUserRepository) 
        {
            this.emailValidationService = emailValidationService;
            this.checkUserService = checkUserService;
            this.addUserRepository = addUserRepository;            
        }
        public UserRegistrationResponseEntity RegisterUser(UserRegistrationRequestEntity userRegistrationRequestEntity)
        {
            try 
            {
                if (userRegistrationRequestEntity.UserEmailAddress == string.Empty
                || (!emailValidationService.ValidateEmailFormat(userRegistrationRequestEntity.UserEmailAddress)))
                {
                    throw new Exception("Email is empty or not in correct format.");
                }

                else if (userRegistrationRequestEntity.phoneNumber.Length != 10)
                {
                    throw new Exception("Mobile Number is not of correct length");
                }

                else
                {
                    int userID = checkUserService.GetUserID(userRegistrationRequestEntity.UserEmailAddress);
                    if (userID == 0)
                    {
                        int cusutomerId = IdGenerationService.GenerateUserId(userRegistrationRequestEntity);
                        userRegistrationRequestEntity.customer_Id = cusutomerId;
                        userRegistrationRequestEntity.Password = PasswordEncryptorService.PasswordEncryptorService.EncryptPassword(userRegistrationRequestEntity.Password);
                        if (addUserRepository.AddUserToDb(userRegistrationRequestEntity))
                        {
                            return new UserRegistrationResponseEntity
                            {
                                Success = true                                
                            };
                        }
                        else 
                        {
                            throw new Exception("We are facing issues while registering new user, please try again.");
                        }
                    }
                    throw new Exception("EmailAddress Already Exist.");
                }
            }
        
            catch (Exception ex) 
            {
                return new UserRegistrationResponseEntity { 
                    Success = false, 
                    MessageResponseEntity = new ErrorMessageResponseEntity 
                    { Message = ex.Message.ToString() } 
                };
            }
        }
    }
}
