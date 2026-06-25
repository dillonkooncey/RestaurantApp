using System;
using RestaurantApp.Database;
using RestaurantApp.Results;

namespace RestaurantApp.Controllers
{
    public class UsersController
    {
        public Result LogIn(string username, string password)
        {
            UsersDb db = new();

            return db.LogIn(username, password);
            
        }
    }
}
