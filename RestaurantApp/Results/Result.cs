namespace RestaurantApp.Results
{
    public class Result
    {
        public bool Success { get; set; }
        public string Reason { get; set; }

        public Result(bool success, string reason = "")
        {
            Success = success;
            Reason = reason;
        }
    }

    public class Result<T> : Result
    {
        public T? Data { get; set; }

        public Result(bool success, string reason = "", T? data = default)
            : base(success, reason)
        {
            Data = data;
        }
    }
}