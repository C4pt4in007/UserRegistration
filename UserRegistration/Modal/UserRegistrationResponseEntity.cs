namespace UserRegistration.Modal
{
    public class UserRegistrationResponseEntity
    {
        private bool success;
        private ErrorMessageResponseEntity errorMessageResponseEntity =  new ErrorMessageResponseEntity { };

        public ErrorMessageResponseEntity MessageResponseEntity 
        { get { return errorMessageResponseEntity; } set { errorMessageResponseEntity = value; } }
        

        public bool Success
        { get { return success; } set { success = value; } }
    }
}
