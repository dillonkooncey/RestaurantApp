namespace RestaurantApp.Models
{
    public class Table
    {
        public int Id { get; set; }

        public int Seats { get; set; }

        public int Available { get; set; }

        public Table(int idParam, int seatsParam, int avaialableParam)
        {
            this.Id = idParam;
            this.Seats = seatsParam;
            this.Available = avaialableParam;
        }
    }
}
