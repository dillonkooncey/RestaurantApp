using Microsoft.Identity.Client;
using RestaurantApp.Controllers;
using RestaurantApp.Models;
using RestaurantApp.Models.Enumerations;
using RestaurantApp.Models.Results;
using System.Security.Cryptography.X509Certificates;
namespace RestaurantApp.Views
{
    public class Start
    {
        private bool successfulLogin = false;
        private UsersController? controller;
        private DBResult<User>? result;

        public void StartApp()
        {
            Console.WriteLine("Welcome...Please Sign in");

            while (!successfulLogin)
            {
                // Make sure the user enters a value
                string username;
                do
                {
                    Console.Write("Username: ");
                    username = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(username))
                    {
                        Console.WriteLine("This field is required. Please enter a value.");
                    }

                } while (string.IsNullOrWhiteSpace(username));


                // Make sure the user enters a value
                string password;
                do
                {
                    Console.Write("Password: ");
                    password = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(password))
                    {
                        Console.WriteLine("This field is required. Please enter a value.");
                    }

                } while (string.IsNullOrWhiteSpace(password));

                // Initialize the UserController to perform the user validation
                controller = new UsersController();
                result = controller.LogIn(username, password);

                // Check to see if we found a valid user
                if (!result.Passed)
                {
                    Console.WriteLine("Could not find user based on the entered credentials. Try again..");
                } else
                {
                    successfulLogin = true; // End the do/while loop now that we have a successful login attempt
                }
            }

            // Create a new User object with the logged in user information so that the other views can use the information
            User loggedInUser = result.RowsList[0];

            // Utilize the role enumeration class
            RoleEnumeration role = (RoleEnumeration)result.RowsList[0].RoleId;

            // Now check the role
            switch (role)
            {
                case RoleEnumeration.Owner:
                    Owner own = new Owner(loggedInUser);
                    own.Start();
                    break;

                case RoleEnumeration.Host:
                    Host host = new Host(loggedInUser);
                    host.Start();
                    break;

                case RoleEnumeration.Waiter:
                    Waiter waiter = new Waiter(loggedInUser);
                    waiter.Start();
                    break;

                default:
                    Console.WriteLine("Unknown role.");
                    break;
            }
        }
    }
}
