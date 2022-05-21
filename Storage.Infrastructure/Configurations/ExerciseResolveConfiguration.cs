using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Domain.ExerciseData;

namespace Storage.Infrastructure.Configurations;

internal class ExerciseResolveConfiguration : IEntityTypeConfiguration<ExerciseResolve>
{
    public void Configure(EntityTypeBuilder<ExerciseResolve> builder)
    {
        builder.ToTable(nameof(ExerciseResolve))
            .HasKey(e => e.Id);

        builder.HasOne(e => e.Exercise)
            .WithMany(e => e.ExerciseResolves)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.User)
            .WithMany(u => u.ResolvedExercises)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(e => e.Resolve)
            .IsRequired()
            .HasMaxLength(10000);

        builder.Property(e => e.SendingDate)
            .IsRequired();

        builder.Property(e => e.ExecutionTime)
            .IsRequired();
    }
}
