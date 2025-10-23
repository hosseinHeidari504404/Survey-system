using Survey_system.Models.Entities;

namespace Survey_system.Interfaces.IRepositores
{
    public interface IVoteRepository
    {
        List<Vote> GetAllVotes();
        List<Vote> GetAll();
        Vote GetById(int id);
        void Add(Vote vote);
        void Delete(int id);
    }
}
