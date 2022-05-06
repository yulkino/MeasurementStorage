using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Domain.ExerciseData;

namespace Storage.Infrastructure.Configurations;

internal class TestCaseConfiguration : IEntityTypeConfiguration<TestCase>
{
    public void Configure(EntityTypeBuilder<TestCase> builder)
    {
        builder.ToTable(nameof(TestCase))
            .HasKey(tc => tc.Id);

        builder.HasOne(tc => tc.Exercise)
            .WithMany(e => e.TestCases);
    }
}
