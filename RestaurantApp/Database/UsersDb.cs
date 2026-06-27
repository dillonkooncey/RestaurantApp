using Microsoft.Data.SqlClient;
using RestaurantApp.Models;
using RestaurantApp.Models.Results;
using System;

namespace RestaurantApp.Database
{
    public class UsersDb
    {
        public DBResult<User> LogIn(string usernameParam, string passwordParam)
        {
            using SqlConnection conn = DbConnectionFactory.CreateConnection();

            try
            {
                conn.Open();

                // Search for approved users with the entered users
                const string accessString =
                    @"select Top 1
	                    *
                    from Users
                    where
	                    Username = @username
	                    and Password = @password
                        and Approved = 1";
                using SqlCommand command = new(accessString, conn);

                command.Parameters.AddWithValue("@username", usernameParam);
                command.Parameters.AddWithValue("@password", passwordParam);

                using SqlDataReader reader = command.ExecuteReader();

                List<User> users = new List<User>();

                // Check to see if we could find a user with the entered information
                while (reader.Read())
                {
                    // Extract all Table object info from query result
                    int id = Convert.ToInt32(reader["Id"]);
                    string username = Convert.ToString(reader["Username"]);
                    string password = Convert.ToString(reader["Password"]);
                    int role = Convert.ToInt32(reader["RoleId"]);
                    int approved = Convert.ToInt32(reader["Approved"]);


                    // Create new table object with extracted data
                    User foundUser = new User(id, username, password, role, approved);

                    users.Add(foundUser);
                }

                if(users.Count > 0)
                {
                    return new DBResult<User>(true, "Found User", users);
                }

                return new DBResult<User>(false, "Could not find user with entered credentials");
            }
            catch (Exception ex)
            {
                return new DBResult<User>(false, $"Connection to DB Failed: {ex.Message}");
            }
        }
    }
}
