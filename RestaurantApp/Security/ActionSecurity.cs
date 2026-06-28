using RestaurantApp.Models;
using RestaurantApp.Models.Enumerations;
using System.Data;

namespace RestaurantApp.Security
{
    public class ActionSecurity
    {
        // Function that gets all the allowed actions based on the passed in Role Enum
        public static List<AppAction> GetAllowedActions(RoleEnumeration roleParam)
        {
            List<AppAction> allActions = GetAllActions();

            return allActions.Where(action => action.AllowedRoles.Contains(roleParam)).ToList();

        }

        // Function that returns a list of all actions with their display names and allowed roles
        private static List<AppAction> GetAllActions()
        {
            return new List<AppAction>
            {
                new AppAction(
                    ActionEnumeration.GET_ALL_TABLES,
                    "Get All Tables",
                    new List<RoleEnumeration>
                    {
                        RoleEnumeration.Owner,
                        RoleEnumeration.Host,
                        RoleEnumeration.Waiter
                    }
                ),
                new AppAction(
                    ActionEnumeration.GET_ALL_AVAILABLE_TABLES,
                    "Get All Available Tables",
                    new List<RoleEnumeration>
                    {
                        RoleEnumeration.Owner,
                        RoleEnumeration.Host,
                        RoleEnumeration.Waiter
                    }
                ),
                new AppAction(
                    ActionEnumeration.CHECK_AVAILABILITY_BY_PERSON_COUNT,
                    "Check Table Availability by Party Size",
                    new List<RoleEnumeration>
                    {
                        RoleEnumeration.Owner,
                        RoleEnumeration.Host,
                        RoleEnumeration.Waiter
                    }
                ),
                new AppAction(
                    ActionEnumeration.INSERT_TABLE,
                    "Create New Table",
                    new List<RoleEnumeration>
                    {
                        RoleEnumeration.Owner
                    }
                ),
                new AppAction(
                    ActionEnumeration.REMOVE_TABLE,
                    "Remove Table",
                    new List<RoleEnumeration>
                    {
                        RoleEnumeration.Owner
                    }
                ),
                new AppAction(
                    ActionEnumeration.ADD_USER,
                    "Add New User",
                    new List<RoleEnumeration>
                    {
                        RoleEnumeration.Owner
                    }
                ),
                new AppAction(
                    ActionEnumeration.UPDATE_USER,
                    "Update Existing User",
                    new List<RoleEnumeration>
                    {
                        RoleEnumeration.Owner
                    }
                ),
                new AppAction(
                    ActionEnumeration.REMOVE_USER,
                    "Remove Existing User",
                    new List<RoleEnumeration>
                    {
                        RoleEnumeration.Owner
                    }
                ),
                new AppAction(
                    ActionEnumeration.APPROVE_ACCESS,
                    "Approve User Access",
                    new List<RoleEnumeration>
                    {
                        RoleEnumeration.Owner
                    }
                )
            };
        }
    }
}
