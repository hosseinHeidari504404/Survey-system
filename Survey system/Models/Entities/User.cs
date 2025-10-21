using Survey_system.Models.Enums;
namespace Survey_system.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public List<Vote> Votes { get; set; }
        public List<Survey> CreatedSurveys { get; set; }
    }
}
