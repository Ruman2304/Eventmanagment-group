using EventManagement.Api.Models;
using System.Linq;

namespace EventManagement.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public List<User> GetUsers()
        {
            return _users;
        }

        public User? GetUserById(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public User CreateUser(User input)
        {
            var user = new User
            {
                Id = input.Id == Guid.Empty ? Guid.NewGuid() : input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                CreatedAt = input.CreatedAt == default ? DateTime.UtcNow : input.CreatedAt
            };

            _users.Add(user);
            return user;
        }
    }
}
