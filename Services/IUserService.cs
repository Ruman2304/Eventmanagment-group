using EventManagement.Api.Models;

namespace EventManagement.Api.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        User? GetUserById(Guid id);
        User CreateUser(User input);
    }
}