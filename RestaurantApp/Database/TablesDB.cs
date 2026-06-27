using Microsoft.Data.SqlClient;
using RestaurantApp.Models;
using RestaurantApp.Models.Results;

namespace RestaurantApp.Database
{
    public class TablesDb
    {
        /*
         * Function used to add a new table to the database
         */
        public DBResult<Table> InsertTable(int seatsParam)
        {
            using SqlConnection conn = DbConnectionFactory.CreateConnection();

            try
            {
                conn.Open();

                const string insertString = @"
                    INSERT INTO [Tables] (Seats, Available)
                    VALUES (@seatsParam, 1);
                ";

                using SqlCommand command = new SqlCommand(insertString, conn);

                command.Parameters.AddWithValue("@seatsParam", seatsParam);

                // ExecuteNonQuery() used when inserting into table
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return new DBResult<Table>(true);
                }
                else
                {
                    return new DBResult<Table>(false, "Table was not added.");
                }
            }
            catch (Exception ex)
            {
                return new DBResult<Table>(false, $"Connection to DB failed: {ex.Message}");
            }
        }

        /*
         * Function to check if there is a table avaiable for the given number of people
         */
        public DBResult<Table> CheckAvailabilityByPersonCount(int numPeople)
        {
            using SqlConnection conn = DbConnectionFactory.CreateConnection();

            try
            {
                conn.Open();

                const string availabilityString = "SELECT 1 FROM Tables WHERE Seats >= @numPeople and Available = 1";
                using SqlCommand command = new SqlCommand(availabilityString, conn);

                command.Parameters.AddWithValue("@numPeople", numPeople);

                using SqlDataReader reader = command.ExecuteReader();

                // Check to see if there is at least 1 table available where we have enough seats for the party
                if (reader.Read())
                {
                    return new DBResult<Table>(true);
                }
                else
                {
                    return new DBResult<Table>(false, "Could not find a table with enough seats");
                }
            }
            catch (Exception ex)
            {
                return new DBResult<Table>(false, $"Connection to DB Failed: {ex.Message}");
            }
        }

        /*
         * Function to get all tables that can accomodate the desired # of people
         */
        public DBResult<Table> getAllAvailableTables(int numPeople)
        {
            using SqlConnection conn = DbConnectionFactory.CreateConnection();

            try
            {
                conn.Open();

                const string availabilityString = "SELECT * FROM Tables WHERE Seats >= @numPeople and Available = 1";
                using SqlCommand command = new SqlCommand(availabilityString, conn);

                command.Parameters.AddWithValue("@numPeople", numPeople);

                using SqlDataReader reader = command.ExecuteReader();

                // Create new List of Tables for the TableResult return
                List<Table> tables = new List<Table>();

                // While loop for all rows returned from reader
                while (reader.Read())
                {
                    // Extract all Table object info from query result
                    int id = Convert.ToInt32(reader["Id"]);
                    int seats = Convert.ToInt32(reader["Seats"]);
                    int available = Convert.ToInt32(reader["Available"]);

                    // Create new table object with extracted data
                    Table table = new Table(id, seats, available);

                    tables.Add(table);
                }

                // Base case for if the Tables list is empty
                if (tables.Count > 0)
                {
                    return new DBResult<Table>(true, "Available tables found.", tables);
                }

                // If we get here there were no tables avaialable
                return new DBResult<Table>(false, "Could not find a table with enough seats.");

            }
            catch (Exception ex)
            {
                return new DBResult<Table>(false, $"Connection to DB Failed: {ex.Message}");
            }
        }

        /*
         * Function to remove a table from the database
         */
        public DBResult<Table> RemoveTable(int idParam)
        {
            using SqlConnection conn = DbConnectionFactory.CreateConnection();

            try
            {
                conn.Open();

                const string removeString = @"
                    DELETE FROM [Tables]
                    WHERE Id = @idParam;
                ";

                using SqlCommand command = new SqlCommand(removeString, conn);

                command.Parameters.AddWithValue("@idParam", idParam);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return new DBResult<Table>(true, "Table removed successfully.");
                }
                else
                {
                    return new DBResult<Table>(false, "Could not find a table with that Id.");
                }
            }
            catch (Exception ex)
            {
                return new DBResult<Table>(false, $"Connection to DB failed: {ex.Message}");
            }
        }

        /*
         * Function that gets all tables currently in the Database
         */
        public DBResult<Table> GetAllTables()
        {
            using SqlConnection conn = DbConnectionFactory.CreateConnection();

            try
            {
                conn.Open();

                const string tablesString = "SELECT * FROM Tables";
                using SqlCommand command = new SqlCommand(tablesString, conn);

                using SqlDataReader reader = command.ExecuteReader();

                // Create new List of Tables for the TableResult return
                List<Table> tables = new List<Table>();

                // While loop for all rows returned from reader
                while (reader.Read())
                {
                    // Extract all Table object info from query result
                    int id = Convert.ToInt32(reader["Id"]);
                    int seats = Convert.ToInt32(reader["Seats"]);
                    int available = Convert.ToInt32(reader["Available"]);

                    // Create new table object with extracted data
                    Table table = new Table(id, seats, available);

                    tables.Add(table);
                }

                // If we found tables
                if (tables.Count > 0)
                {
                    return new DBResult<Table>(true, "Pulled all tables", tables);
                }

                // If we get here there were no tables available
                return new DBResult<Table>(true, "There currently no tables in the restaurant.");
            }
            catch (Exception ex)
            {
                return new DBResult<Table>(false, $"Connection to DB Failed: {ex.Message}");
            }
        }
    }
}