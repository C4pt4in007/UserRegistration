using UserRegistration.Modal;

namespace UserRegistration.Service
{
    public class IdGenerationService
    {
        public IdGenerationService() { }

        public static int GenerateUserId(UserRegistrationRequestEntity userRegistrationRequestEntity) 
        {
            string uniqueId = "" + userRegistrationRequestEntity.phoneNumber.Substring(10);
            DateTime dateTime = DateTime.Now;
            uniqueId = uniqueId + dateTime.Day + dateTime.Hour + dateTime.Year;
            return Int32.Parse(uniqueId);
        }
    }
}
