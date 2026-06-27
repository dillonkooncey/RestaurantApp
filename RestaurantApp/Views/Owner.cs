using RestaurantApp.Controllers;
using RestaurantApp.Models;

namespace RestaurantApp.Views
{
    public class Owner
    {
        public UsersController _usersController = new UsersController();

        private User currentUser;

        public Owner(User loggedInUser)
        {
            this.currentUser = loggedInUser;
        }
        public void Start()
        {
            Console.WriteLine("Welcome Owner...");
            Console.WriteLine("Current User: " + currentUser.Username);
        }
    }
}