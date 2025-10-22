using Survey_system.Infrastructure.Repositories;
using Survey_system.Interfaces.IServices;
using Survey_system.Models.Entities;
namespace Survey_system.Services
{
    public class OptionService: IOptionService
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
    }
}

