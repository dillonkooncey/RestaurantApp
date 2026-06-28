namespace RestaurantApp.Models.Enumerations
{
    public enum ActionEnumeration
    {
        // Table Actions
        GET_ALL_TABLES = 1,
        GET_ALL_AVAILABLE_TABLES = 2,
        CHECK_AVAILABILITY_BY_PERSON_COUNT = 3,
        INSERT_TABLE = 4,
        REMOVE_TABLE = 5,

        // User Actions
        ADD_USER = 6,
        UPDATE_USER = 7,
        REMOVE_USER = 8,
        APPROVE_ACCESS = 9
    }
}