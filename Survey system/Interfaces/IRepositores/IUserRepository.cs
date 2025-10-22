using Survey_system.Models.Entities;

namespace Survey_system.Interfaces.IRepositores
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
