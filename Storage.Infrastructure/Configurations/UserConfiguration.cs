using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Domain.UserData;

namespace Storage.Infrastructure.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User))
            .HasKey(u => u.Id);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(320);

        builder.Property(u => u.Login)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(200);
            
        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.HasIndex(u => u.Login)
            .IsUnique();

        builder.HasMany(u => u.ResolvedExercises)
            .WithOne(e => e.User);

        builder.HasMany(u => u.CreatedExercises)
            .WithOne(e => e.Author);

        builder.HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity("UserRoles");
    }
}
