using RestaurantApp.Controllers;
using RestaurantApp.Models.Results;
using RestaurantApp.Models;
namespace RestaurantApp.Views
{
    public class Start
    {
        public void StartApp()
        {
            TablesController control = new TablesController();

            DBResult<Table> result = control.getTableAvailabilityByPersonCount(4);

            if(result.Passed)
            {
                Console.WriteLine("There is a table available");
            } else
            {
                Console.WriteLine("No tables available at this time");
            }
        }
    }
}
