namespace RestaurantApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public int Approved { get; set; }

        public User(int idParam, string usernameParam, string passwordParam, int roleIdParam, int approvedParam)
        {
            this.Id = idParam;
            this.Username = usernameParam;
            this.Password = passwordParam;
            this.RoleId = roleIdParam;
            this.Approved = approvedParam;
        }
    }
}
