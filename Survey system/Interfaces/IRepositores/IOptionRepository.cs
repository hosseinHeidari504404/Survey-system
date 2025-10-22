using Survey_system.Models.Entities;

namespace Survey_system.Interfaces.IRepositores
{
    public interface IOptionRepository
    {
        List<Option> GetAll();
        Option GetById(int id);
        void Add(Option option);
        void Update(Option option);
        void Delete(int id);
    }
}
