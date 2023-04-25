using MySql.Data.MySqlClient;

namespace UserRegistration.UserDAO
{
    public interface IMySQLConnection
    {
        MySqlConnection getConnectionObject();
    }
}
