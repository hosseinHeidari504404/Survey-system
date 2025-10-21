using Microsoft.EntityFrameworkCore;
using Survey_system.Models.Entities;
namespace Survey_system.Infrastructure.Repositories
{
    public class SurveyRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<Survey> GetAll()
        {
            return _context.Surveys
                .Include(x => x.Questions)
                .ThenInclude(q => q.Options)
                .ToList();
        }

        public Survey GetById(int id)
        {
            return _context.Surveys
                .Include(x => x.Questions)
                .ThenInclude(q => q.Options)
                .FirstOrDefault(x => x.Id == id)!;
        }

        public void Add(Survey survey)
        {
            _context.Surveys.Add(survey);
            _context.SaveChanges();
        }

        public void Update(Survey survey)
        {
            _context.Surveys.Update(survey);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var survey = _context.Surveys.Find(id);
            if (survey != null)
            {
                _context.Surveys.Remove(survey);
                _context.SaveChanges();
            }
        }
    }
}


