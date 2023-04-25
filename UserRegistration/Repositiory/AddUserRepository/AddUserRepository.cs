using System.Data;
using UserRegistration.Modal;
using UserRegistration.UserDAO;

namespace UserRegistration.Repositiory.AddUserRepository
{
    public class AddUserRepository : IAddUserRepository
    {
        private IMySQLConnection mySQLConnection;

        public AddUserRepository(IMySQLConnection mySQLConnection)
        {
            this.mySQLConnection = mySQLConnection;
        }
        public bool AddUserToDb(UserRegistrationRequestEntity userRegistrationRequestEntity)
        {
            IDbConnection dbConnection = mySQLConnection.getConnectionObject();
            try 
            {
                dbConnection.Open();
                string registerCustomerQuery = "Insert into customers values( ";
                registerCustomerQuery = registerCustomerQuery + userRegistrationRequestEntity.customer_Id + ", '" + userRegistrationRequestEntity.FName + "', '" + userRegistrationRequestEntity.MName + "', ";
                registerCustomerQuery = registerCustomerQuery + "'" + userRegistrationRequestEntity.LName + "', '" + userRegistrationRequestEntity.UserEmailAddress + "', '" + userRegistrationRequestEntity.Password + "', ";
                registerCustomerQuery = registerCustomerQuery + userRegistrationRequestEntity.phoneNumber + ", Now(), NULL)";
                using (IDbCommand command = dbConnection.CreateCommand()) 
                {
                    command.CommandText = registerCustomerQuery;
                    int recordAdded = command.ExecuteNonQuery();
                    if (recordAdded > 0)
                        return true;
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }         
            return false;
        }
    }
}
