using RestaurantApp.Models;

namespace RestaurantApp.Views
{
    public class Waiter
    {
        private User currentUser;

        public Waiter(User loggedInUser)
        {
            this.currentUser = loggedInUser;
        }
        public void Start()
        {
            Console.WriteLine("Welcome Waiter...");
        }
    }
}
