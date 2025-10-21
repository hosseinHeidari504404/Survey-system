using Microsoft.EntityFrameworkCore;
using Survey_system.Models.Entities;
namespace Survey_system.Infrastructure.Repositories
{

    public class QuestionRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<Question> GetAll()
        {
            return _context.Questions.Include(x => x.Options).ToList();
        }

        public Question GetById(int id)
        {
            return _context.Questions
                .Include(x => x.Options)
                .FirstOrDefault(x => x.Id == id)!;
        }

        public void Add(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public void Update(Question question)
        {
            _context.Questions.Update(question);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var question = _context.Questions.Find(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }
    }
}
