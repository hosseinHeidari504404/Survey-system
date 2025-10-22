using Survey_system.Interfaces.IRepositores;
using Survey_system.Models.Entities;
namespace Survey_system.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context = new AppDbContext();
        public User GetByUsername(string username) => _context.Users.FirstOrDefault(x => x.Username == username);

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}

