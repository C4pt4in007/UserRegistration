namespace UserRegistration.Modal
{
    public class UserRegistrationRequestEntity
    {
        public int customer_Id { get; set; }
        public string phoneNumber { get; set; } = string.Empty;

        public string UserEmailAddress { get; set; } = string.Empty;
        
        public string FName { get; set; } = string.Empty;

        public string MName { get; set; } = string.Empty;

        public string LName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
