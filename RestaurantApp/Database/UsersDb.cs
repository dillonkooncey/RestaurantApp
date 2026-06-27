//using Microsoft.Data.SqlClient;
//using RestaurantApp.Database;
//using RestaurantApp.Results;
//using System;

//namespace RestaurantApp.Database
//{
//    public class UsersDb
//    {
//        public Result LogIn(string username, string password)
//        {
//            using SqlConnection conn = DbConnectionFactory.CreateConnection();

//            try
//            {
//                conn.Open();

//                const string accessString = "SELECT 1 FROM Users WHERE Username = @username and Password = @password";
//                using SqlCommand command = new(accessString, conn);

//                command.Parameters.AddWithValue("@username", username);
//                command.Parameters.AddWithValue("@password", password);

//                using SqlDataReader reader = command.ExecuteReader();

//                // Check to see if we could find a user with the entered information
//                if (reader.Read())
//                {
//                    return new Result(true);
//                }
//                else
//                {
//                    return new Result(false, "Username and Password not found. Try again...");
//                }
//            }
//            catch (Exception ex)
//            {
//                return new Result(false, $"Connection to DB Failed: {ex.Message}");
//            }
//        }
//    }
//}
