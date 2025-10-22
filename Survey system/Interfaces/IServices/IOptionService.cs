namespace Survey_system.Interfaces.IServices
{
    public interface IOptionService
    {
        void AddOption(int questionId, string text);
    }
}
