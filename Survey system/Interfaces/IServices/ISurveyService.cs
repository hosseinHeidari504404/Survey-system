using Survey_system.Models.Entities;

namespace Survey_system.Interfaces.IServices
{
    public interface ISurveyService
    {
        void CreateSurvey(string title, int userId);
        List<Survey> GetAllSurveys();
        Survey GetSurveyById(int id);
        void DeleteSurvey(int id);
    }
}
