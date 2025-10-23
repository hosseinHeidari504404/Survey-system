using Survey_system.Infrastructure.Repositories;
using Survey_system.Interfaces.IServices;
using Survey_system.Models.Entities;
namespace Survey_system.Services
{
    public class VoteService: IVoteService
    {
        private readonly VoteRepository _repository;

        public VoteService(VoteRepository repository)
        {
            _repository = repository;
        }
        public void AddVote(int userId, int questionId, int optionId)
            {
                var mojodVote = _repository.GetAllVotes()
                    .FirstOrDefault(v => v.UserId == userId && v.QuestionId == questionId);

                if (mojodVote != null)
                    throw new Exception("You have already voted for this question.");

                var vote = new Vote
                {
                    UserId = userId,
                    QuestionId = questionId,
                    OptionId = optionId,
                    VotedOn = DateTime.Now
                };

                _repository.Add(vote);
                Console.WriteLine("Vote registered successfully.");
            }
        public List<Vote> GetAllVotes()
        {
            // return _repository.GetAll();
            return _repository.GetAllVotes();
        }
    }
}
