using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Domain.ExerciseData;

namespace Storage.Infrastructure.Configurations;

internal class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable(nameof(Exercise))
            .HasKey(e => e.Id);

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(e => e.CreationDate)
            .IsRequired();

        builder.HasMany(e => e.TestCases)
            .WithOne(tc => tc.Exercise)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasOne(e => e.Author)
            .WithMany(u => u.CreatedExercises)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}
