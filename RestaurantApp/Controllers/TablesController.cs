using System;
using Microsoft.Identity.Client;
using RestaurantApp.Database;
using RestaurantApp.Results;

namespace RestaurantApp.Controllers
{
    // Controller that handles all traffic to and from the tables DB to the views
    public class TablesController
    {
        public Result getTableAvailability(int numSeats)
        {
            TablesDb tableDb = new TablesDb();

            // Return the Result returned from the Db call
            return tableDb.CheckAvailability(numSeats);
        }
    }
}
