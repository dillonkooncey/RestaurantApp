namespace RestaurantApp.Models.Results
{
    // Generic class used to return responses from the DB's
    public class DBResult<T>
    {
        public bool Passed { get; set; }

        public string Reason { get; set; }

        public List<T> RowsList { get; set; }

        public DBResult(bool passedParam, string reasonParam = "", List<T> listParam = null)
        {
            this.Passed = passedParam;
            this.Reason = reasonParam;
            this.RowsList = listParam;
        }
    }
}
