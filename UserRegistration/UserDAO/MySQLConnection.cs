using MySql.Data.MySqlClient;

namespace UserRegistration.UserDAO
{
    public class MySQLConnection : IMySQLConnection
    {
        private string connectionString = "server=localhost;port=3306;database=takeawaysystem;user=root;password=admin";

        public MySqlConnection getConnectionObject()
        {
            MySqlConnection? connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
            }

            if (connection == null) 
            {
                throw new Exception("There was some issue creating connection.");
            }

            return connection;
        }
    }
}
