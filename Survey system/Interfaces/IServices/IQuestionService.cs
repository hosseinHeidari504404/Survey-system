using Survey_system.Models.Entities;

namespace Survey_system.Interfaces.IServices
{
    public interface IQuestionService
    {
        void AddQuestion(int surveyId, string text);
        List<Question> GetAllQuestions();
    }
}
