using RestaurantApp.Models.Enumerations;

namespace RestaurantApp.Models
{
    // Model that handles app actions and how it is displayed to the user
    public class AppAction
    {
        public ActionEnumeration Enumeration { get; set; }

        public string Name { get; set; }

        public List<RoleEnumeration> AllowedRoles = new List<RoleEnumeration>();

        public AppAction(ActionEnumeration enumParam, string nameParam, List<RoleEnumeration> allowedRolesParam)
        {
            this.Enumeration = enumParam;
            this.Name = nameParam;
            this.AllowedRoles = allowedRolesParam;
        }
    }
}
