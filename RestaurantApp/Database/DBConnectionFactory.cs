using Microsoft.Data.SqlClient;

namespace RestaurantApp.Database
{
    // Class that holds the connection strings used for the DB calls
    public static class DbConnectionFactory
    {
        private const string ConnectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-NetFlixApplication-f48077b8-8a4d-4abe-a72f-6c2cc190875e;Integrated Security=True;";

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}