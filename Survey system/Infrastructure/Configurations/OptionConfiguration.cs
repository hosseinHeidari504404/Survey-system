using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey_system.Models.Entities;
namespace Survey_system.Infrastructure.Configurations
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("Options");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(x => x.Question)
                .WithMany(x => x.Options)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Votes)
                .WithOne(x => x.Option)
                .HasForeignKey(x => x.OptionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

