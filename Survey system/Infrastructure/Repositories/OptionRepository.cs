using Microsoft.EntityFrameworkCore;
using Survey_system.Models.Entities;
namespace Survey_system.Infrastructure.Repositories
{
    public class OptionRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<Option> GetAll()
        {
            return _context.Options.Include(x => x.Question).ToList();
        }

        public Option GetById(int id)
        {
            return _context.Options
                .Include(x => x.Question)
                .FirstOrDefault(x => x.Id == id)!;
        }

        public void Add(Option option)
        {
            _context.Options.Add(option);
            _context.SaveChanges();
        }

        public void Update(Option option)
        {
            _context.Options.Update(option);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var option = _context.Options.Find(id);
            if (option != null)
            {
                _context.Options.Remove(option);
                _context.SaveChanges();
            }
        }
    }
}


