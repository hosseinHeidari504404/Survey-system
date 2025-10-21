using Survey_system.Infrastructure.Repositories;
using Survey_system.Models.Entities;
namespace Survey_system.Services
{
    public class QuestionService
    {
        private readonly QuestionRepository _repository;

        public QuestionService(QuestionRepository repository)
        {
            _repository = repository;
        }

        public void AddQuestion(int surveyId, string text)
        {
            var question = new Question
            {
                SurveyId = surveyId,
                Text = text
            };

            _repository.Add(question);
            Console.WriteLine("Question added successfully.");
        }

        public List<Question> GetAllQuestions()
        {
            return _repository.GetAll();
        }

        public Question GetQuestionById(int id)
        {
            return _repository.GetById(id);
        }

        public void DeleteQuestion(int id)
        {
            _repository.Delete(id);
            Console.WriteLine("Question deleted successfully.");
        }
    }
}
