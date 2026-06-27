using RestaurantApp.Models;
using System.Runtime.CompilerServices;

namespace RestaurantApp.Views
{
    public class Host
    {
        private User currentUser;

        public Host(User loggedInUser) 
        {
            this.currentUser = loggedInUser;
        }
        public void Start()
        {
            Console.WriteLine("Welcome Host...");
        }
    }
}
