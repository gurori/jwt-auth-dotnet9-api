namespace Core.Models
{
    public class User
    {
        public string Id { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Email { get; set; } = null!;

        public User() { }

        public User(string id, string role, string email)
        {
            Id = id;
            Role = role;
        }
    }
}
