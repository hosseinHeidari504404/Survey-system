using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey_system.Models.Entities;
namespace Survey_system.Infrastructure.Configurations
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("Surveys");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(x => x.CreatedByUser)
                .WithMany(x => x.CreatedSurveys)
                .HasForeignKey(x => x.CreatedByUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Questions)
                .WithOne(x => x.Survey)
                .HasForeignKey(x => x.SurveyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

