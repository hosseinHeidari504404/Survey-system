using Survey_system.Infrastructure.Repositories;
using Survey_system.Models.Entities;
namespace Survey_system.Services
{
    public class OptionService
    {
        private readonly OptionRepository _repository;

        public OptionService(OptionRepository repository)
        {
            _repository = repository;
        }

        public void AddOption(int questionId, string text)
        {
            var option = new Option
            {
                QuestionId = questionId,
                Text = text
            };

            _repository.Add(option);
            Console.WriteLine("Option added successfully.");
        }

        public List<Option> GetAllOptions()
        {
            return _repository.GetAll();
        }

        public Option GetOptionById(int id)
        {
            return _repository.GetById(id);
        }

        public void DeleteOption(int id)
        {
            _repository.Delete(id);
            Console.WriteLine("Option deleted successfully.");
        }
    }
}

