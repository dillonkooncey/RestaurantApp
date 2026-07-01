using RestaurantApp.Models;
using RestaurantApp.Models.Enumerations;
using RestaurantApp.Security;
using RestaurantApp.Views;
using System.Net.NetworkInformation;

namespace RestaurantApp.Controllers
{
    // Controller that handles all movement from views to action viewing
    public class ActionsController
    {
        public static List<AppAction> GetAllowedActions(int RoleIdParam)
        {
            // Get the RoleEnum value based on the passed in RoleId
            RoleEnumeration role = (RoleEnumeration)RoleIdParam;

            return ActionSecurity.GetAllowedActions(role);
        }
}
