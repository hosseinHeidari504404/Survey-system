using Survey_system.Models.Entities;

namespace Survey_system.Interfaces.IServices
{
    public interface IVoteService
    {
        void AddVote(int userId, int questionId, int optionId);
        List<Vote> GetAllVotes();
    }
}
