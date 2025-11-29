namespace DataAccess.Entities
{
    public sealed class UserEntity : BaseEntity
    {
        public string Role { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
