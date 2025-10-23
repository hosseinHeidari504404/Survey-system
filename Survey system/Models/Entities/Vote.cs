namespace Survey_system.Models.Entities
{
    public class Vote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? QuestionId { get; set; }
        public Question? Question { get; set; }
        public int? OptionId { get; set; }
        public Option? Option { get; set; }
        public DateTime VotedOn { get; set; }
    }
}
