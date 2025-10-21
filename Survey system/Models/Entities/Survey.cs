namespace Survey_system.Models.Entities
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public List<Question> Questions { get; set; }
    }
}
