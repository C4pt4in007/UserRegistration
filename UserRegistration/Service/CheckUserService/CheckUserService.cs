using System.Net.Mail;
using UserRegistration.Repositiory.CheckUserRepository;

namespace UserRegistration.Service.CheckUserService
{
    public class CheckUserService : ICheckUserService
    {
        private ICheckUserRepository checkUserRepository;
        public CheckUserService(ICheckUserRepository checkUserRepository) 
        {
            this.checkUserRepository = checkUserRepository;
        }
        public int GetUserID(string emailAddress) 
        {
            return checkUserRepository.getUserID(emailAddress);
        }
    }
}
