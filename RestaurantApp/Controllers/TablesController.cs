using RestaurantApp.Models;
using RestaurantApp.Models.Results;
using RestaurantApp.Database;

namespace RestaurantApp.Controllers
{
    // Controller that handles all traffic to and from the tables DB to the views
    public class TablesController
    {
        // Function that returns the function from then DB that adds a new table to the DB
        public DBResult<Table> InsertTable(int numSeats)
        {
            TablesDb tableDb = new TablesDb();

            // Return the Result returned from the Db call
            return tableDb.InsertTable(numSeats);
        }

        /*
         * Function that returns the response from DB for function that determines if 
           there is a table available based on the number of people trying to be seated
         */
        public DBResult<Table> CheckAvailabilityByPersonCount(int numSeats)
        {
            TablesDb tableDb = new TablesDb();

            // Return the Result returned from the Db call
            return tableDb.CheckAvailabilityByPersonCount(numSeats);
        }

        /*
         * Function that returns the response from DB to get all available tables
         */
        public DBResult<Table> getAllAvailableTables(int numSeats)
        {
            TablesDb tableDb = new TablesDb();

            // Return the Result returned from the Db call
            return tableDb.getAllAvailableTables(numSeats);
        }

        /*
         * Function that returns the response from the DB to remove a table from th DB
         */
        public DBResult<Table> RemoveTable(int tableId)
        {
            TablesDb tableDb = new TablesDb();

            // Return the Result returned from the Db call
            return tableDb.RemoveTable(tableId);
        }

        /*
         * Function that returns the response from the DB that gets all of the tables in the DB
         */
        public DBResult<Table> GetAllTables()
        {
            TablesDb tableDb = new TablesDb();

            // Return the Result returned from the Db call
            return tableDb.GetAllTables();
        }
    }
}
