using RestaurantApp.Controllers;
using RestaurantApp.Models;

namespace RestaurantApp.Views
{
    public class Owner
    {
        public UsersController _usersController = new UsersController();

        private User currentUser;

        // Constructor takes in the current user from the View
        public Owner(User loggedInUser)
        {
            this.currentUser = loggedInUser;
        }
        public void Start()
        {
            // Intro messages
            Console.WriteLine("\nWelcome..." + currentUser.Username);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Here is a list of actions you can take -> ");

            List<AppAction> actionsList = ActionsContoller.GetAllowedActions(currentUser.RoleId);
            for (int i = 0; i < actionsList.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {actionsList[i].Name}");
            }

            // Declare variable to hold the users input
            int desiredAction;
            do
            {
                Console.WriteLine("\nEnter a number for the action you want to take. You must input a valid number: ");
                string? input = Console.ReadLine();

                // Make sure the entered value is an int
                if (!int.TryParse(input, out desiredAction))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                // Make sure the value will be included in the action number
                if (desiredAction < 1 || desiredAction > actionsList.Count)
                {
                    Console.WriteLine("Invalid option. Please choose a number from the menu.");
                    continue;
                }

                break;

            } while (true);

        }
    }
}