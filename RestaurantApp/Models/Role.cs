namespace RestaurantApp.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Role(int idParam, string nameParam)
        {
            this.Id = idParam;
            this.Name = nameParam;
        }
    }
}
