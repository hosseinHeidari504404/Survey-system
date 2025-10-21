using Survey_system.Infrastructure.Repositories;
using Survey_system.Models.Entities;
namespace Survey_system.Services
{
    public class VoteService
    {
        private readonly VoteRepository _repository;

        public VoteService(VoteRepository repository)
        {
            _repository = repository;
        }

        //public void AddVote(int userId, int questionId, int optionId)
        //{
        //    var vote = new Vote
        //    {
        //        UserId = userId,
        //        QuestionId = questionId,
        //        OptionId = optionId,
        //        VotedOn = DateTime.Now
        //    };

        //    _repository.Add(vote);
        //    Console.WriteLine("Vote recorded successfully.");
        //}
        
            public void AddVote(int userId, int questionId, int optionId)
            {
                var existingVote = _repository.GetAllVotesWithRelations()
                    .FirstOrDefault(v => v.UserId == userId && v.QuestionId == questionId);

                if (existingVote != null)
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
            return _repository.GetAllVotesWithRelations();
        }

        public void DeleteVote(int id)
        {
            _repository.Delete(id);
            Console.WriteLine("Vote deleted successfully.");
        }
    }
}
