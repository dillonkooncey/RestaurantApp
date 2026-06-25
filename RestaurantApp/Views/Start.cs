using RestaurantApp.Controllers;
using RestaurantApp.Results;
namespace RestaurantApp.Views
{
    public class Start
    {
        public void StartApp()
        {
            Console.WriteLine("Welcome to the Restaurant App!");
            Console.WriteLine("Enter username:");

            // Create a string variable and get user input from the keyboard and store it in the variable
            string username = Console.ReadLine();

            Console.WriteLine("Enter password:");

            // Create a string variable and get user input from the keyboard and store it in the variable
            string password = Console.ReadLine();


        }
    }
}
