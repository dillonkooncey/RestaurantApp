namespace RestaurantApp.Results
{
    // Class used to return objects throughout the project with a boolean result and string reason that can be default
    public class Result
    {
        public bool ResultValue;
        public string Reason;

        public Result(bool result, string reason = "")
        {
            this.ResultValue = result;
            this.Reason = reason;
        }
    }
}