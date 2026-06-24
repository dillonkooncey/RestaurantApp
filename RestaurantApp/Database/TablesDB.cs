using Microsoft.Data.SqlClient;
using RestaurantApp.Results;

namespace RestaurantApp.Database
{
    public class TablesDb
    {
        public Result CheckAvailability(int numPeople)
        {
            using SqlConnection conn = DbConnectionFactory.CreateConnection();

            try
            {
                conn.Open();

                const string availabilityString = "SELECT 1 FROM Tables WHERE NumSeats >= @numPeople and Available = 1";
                using SqlCommand command = new SqlCommand(availabilityString, conn);

                command.Parameters.AddWithValue("@numPeople", numPeople);

                using SqlDataReader reader = command.ExecuteReader();

                // Check to see if there is at least 1 table available where we have enough seats for the party
                if (reader.Read())
                {
                    return new Result(true);
                }
                else
                {
                    return new Result(false, "Could not find a table with enough seats");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Connection to DB Failed: {ex.Message}");
            }
        }
    }
}