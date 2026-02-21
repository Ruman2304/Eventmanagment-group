using EventManagement.Api.Models;

namespace EventManagement.Api.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User? GetUserById(Guid id);
        User CreateUser(User input);
    }
}