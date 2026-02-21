using EventManagement.Api.Models;
using EventManagement.Api.Repositories;

namespace EventManagement.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public User? GetUserById(Guid id)
        {
            return _userRepository.GetUserById(id);
        }

        public User CreateUser(User input)
        {
            return _userRepository.CreateUser(input);
        }
    }
}