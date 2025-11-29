using Core.Models;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<bool> TryCreateAsync(User user);

        public Task<User?> GetByEmailAsync(string email);

        public Task<User?> GetByIdAsync(string id);
        public Task UpdateAsync(
            string id,
            string lastName,
            string firstName,
            string middleName,
            string description,
            string jobTitle
        );
        public Task<string?> GetRoleByIdAsync(string id);
        public Task<ICollection<User>> GetManyByIdAsync(IEnumerable<string> ids);
        public Task DeleteByIdAsync(string id);
    }
}
