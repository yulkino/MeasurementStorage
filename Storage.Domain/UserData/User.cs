using Microsoft.AspNetCore.Identity;
using Storage.Domain.ExerciseData;

namespace Storage.Domain.UserData;

public sealed class User : IdentityUser<Guid>
{
    public User(string email, string login, string passwordHash, string? avatarUrl, List<Role> roles)
    {
        Id = Guid.NewGuid();
        Email = email;
        Login = login;
        PasswordHash = passwordHash;
        AvatarUrl = avatarUrl;
        Roles = roles;
    }

    public string Login { get; set; }
    public string? AvatarUrl { get; set; }
    public IEnumerable<Role> Roles { get; set; }
    public IEnumerable<Exercise> CreatedExercises { get; set; }
    public IEnumerable<ExerciseResolve> ResolvedExercises { get; set; }

    private User() { }
}
