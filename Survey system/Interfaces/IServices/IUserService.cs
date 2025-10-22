using Survey_system.Models.Entities;
using Survey_system.Models.Enums;

namespace Survey_system.Interfaces.IServices
{
    public interface IUserService
    {
        void Register(string username, string password, UserRole role);
        User Login(string username, string password);
    }
}
