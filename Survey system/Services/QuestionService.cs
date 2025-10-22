using Survey_system.Infrastructure.Repositories;
using Survey_system.Interfaces.IServices;
using Survey_system.Models.Entities;
namespace Survey_system.Services
{
    public class QuestionService: IQuestionService
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
    }
}
