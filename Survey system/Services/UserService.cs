using Survey_system.Infrastructure.Repositories;
using Survey_system.Interfaces.IRepositores;
using Survey_system.Interfaces.IServices;
using Survey_system.Models.Entities;
using Survey_system.Models.Enums;
namespace Survey_system.Services
{
    public class UserService: IUserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public void Register(string username, string password, UserRole role)
        {
            var existingUser = _repository.GetByUsername(username);
            if (existingUser != null)
            {
                Console.WriteLine("Username already exists.");
                return;
            }

            var user = new User
            {
                Username = username,
                Password = password,
                Role = role
            };

            _repository.Add(user);
            Console.WriteLine("User registered successfully.");
        }

        public User Login(string username, string password)
        {
            var user = _repository.GetByUsername(username);
            if (user == null || user.Password != password)
            {
                Console.WriteLine("Invalid username or password.");
                return null;
            }

            Console.WriteLine($"Welcome {user.Username}!");
            return user;
        }
    }
}
