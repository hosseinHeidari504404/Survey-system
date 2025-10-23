using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey_system.Models.Entities;

 namespace Survey_system.Infrastructure.Configurations
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("Votes");
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.User)
            //    .WithMany(x => x.Votes)
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.Restrict); 

            //builder.HasOne(x => x.Question)
            //    .WithMany(x=> x.Votes)
            //    .HasForeignKey(x => x.QuestionId)
            //    .OnDelete(DeleteBehavior.SetNull); 

            //builder.HasOne(x => x.Option)
            //    .WithMany(x => x.Votes)
            //    .HasForeignKey(x => x.OptionId)
            //    .OnDelete(DeleteBehavior.SetNull); 
        }
    }
}
