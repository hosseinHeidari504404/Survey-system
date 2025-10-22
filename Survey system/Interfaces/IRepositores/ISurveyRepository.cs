using Survey_system.Models.Entities;

namespace Survey_system.Interfaces.IRepositores
{
    public interface ISurveyRepository
    {
        List<Survey> GetAll();
        Survey GetById(int id);
        void Add(Survey survey);
        void Update(Survey survey);
        void Delete(int id);
    }
}
