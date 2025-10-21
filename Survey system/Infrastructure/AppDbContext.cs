using Microsoft.EntityFrameworkCore;
using Survey_system.Infrastructure.Configurations;
using Survey_system.Models.Entities;
using Survey_system.Models.Enums;

namespace Survey_system.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Initial Catalog= Survey; Integrated Security=True; Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new SurveyConfiguration().Configure(modelBuilder.Entity<Survey>());
            new QuestionConfiguration().Configure(modelBuilder.Entity<Question>());
            new OptionConfiguration().Configure(modelBuilder.Entity<Option>());
            new VoteConfiguration().Configure(modelBuilder.Entity<Vote>());
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "1234", Role = UserRole.Admin },
                new User { Id = 2, Username = "user", Password = "1234", Role = UserRole.User }
            );
        }
    }
}
