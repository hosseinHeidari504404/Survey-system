using Survey_system.Models.Entities;

namespace Survey_system.Interfaces.IRepositores
{
    public interface IQuestionRepository
    {
        List<Question> GetAll();
        Question GetById(int id);
        void Add(Question question);
        void Update(Question question);
        void Delete(int id);
    }
}
