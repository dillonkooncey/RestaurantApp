using RestaurantApp.Database;
using RestaurantApp.Models;
using RestaurantApp.Models.Results;

namespace RestaurantApp.Controllers
{
    public class UsersController
    {
        private readonly UsersDb _usersDb;
        public User? currentUser;

        public UsersController()
        {
            _usersDb = new UsersDb();
        }

        public DBResult<User> LogIn(string username, string password)
        {
            DBResult<User> result = _usersDb.LogIn(username, password);

            // If the search failed then just send back the response from the DB
            if (!result.Passed)
            {
                return result;
            }

            // If a positive result was returned, go ahead and set the current user
            if (result.RowsList.Count > 0)
            {
                currentUser = result.RowsList[0]; // Can do this since top 1 was queried in the DB
            }

            return result;
        }
    }
}