using Microsoft.EntityFrameworkCore;
using Survey_system.Models.Entities;
using Survey_system.Interfaces.IRepositores;
namespace Survey_system.Infrastructure.Repositories
{
    public class VoteRepository:IVoteRepository
    {
        private readonly AppDbContext _context = new AppDbContext();
        public List<Vote> GetAllVotesWithRelations()
        {
            return _context.Votes
                .Include(v => v.Question)  
                .Include(v => v.Option)    
                .Include(v => v.User)      
                .ToList();
        }

        public List<Vote> GetAll()
        {
            return _context.Votes
                .Include(x => x.User)
                .Include(x => x.Option)
                .ToList();
        }

        public Vote GetById(int id)
        {
            return _context.Votes
                .Include(x => x.User)
                .Include(x => x.Option)
                .FirstOrDefault(x => x.Id == id)!;
        }

        public void Add(Vote vote)
        {
            _context.Votes.Add(vote);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var vote = _context.Votes.Find(id);
            if (vote != null)
            {
                _context.Votes.Remove(vote);
                _context.SaveChanges();
            }
        }
    }
}
