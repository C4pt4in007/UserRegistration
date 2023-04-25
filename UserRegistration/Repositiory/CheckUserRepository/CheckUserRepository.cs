using System.Data;
using UserRegistration.UserDAO;

namespace UserRegistration.Repositiory.CheckUserRepository
{
    public class CheckUserRepository : ICheckUserRepository
    {
        private IMySQLConnection mySQLConnection;
        
        public CheckUserRepository(IMySQLConnection mySQLConnection) 
        {
            this.mySQLConnection = mySQLConnection;
        }
        public int getUserID(string emailAddress)
        {
            IDbConnection dbConnection = mySQLConnection.getConnectionObject();
            try
            {
                dbConnection.Open();
                string getUserQuery = "SELECT * FROM Customers where EmailAddress = '" + emailAddress + "'";
                using (IDbCommand command = dbConnection.CreateCommand())
                {
                    command.CommandText = getUserQuery;
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return (int)reader["Customer_ID"];
                                                
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally {
                dbConnection.Close();
            }
            return 0;
        }
    }
}
