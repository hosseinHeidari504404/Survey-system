using Survey_system.Infrastructure.Repositories;
using Survey_system.Interfaces.IServices;
using Survey_system.Models.Entities;

namespace Survey_system.Services
{
    public class SurveyService: ISurveyService
    {
        private readonly SurveyRepository _repository;

        public SurveyService(SurveyRepository repository)
        {
            _repository = repository;
        }

        public void CreateSurvey(string title, int userId)
        {
            var survey = new Survey
            {
                Title = title,
                CreatedByUserId = userId,
                CreatedOn = DateTime.Now
            };

            _repository.Add(survey);
            Console.WriteLine("Survey created successfully.");
        }

        public List<Survey> GetAllSurveys()
        {
            return _repository.GetAll();
        }

        public Survey GetSurveyById(int id)
        {
            return _repository.GetById(id);
        }

        public void DeleteSurvey(int id)
        {
            _repository.Delete(id);
            Console.WriteLine("Survey deleted successfully.");
        }
    }
}
