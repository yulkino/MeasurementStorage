using Microsoft.AspNetCore.Identity;
using Storage.Domain.ExerciseData;

namespace Storage.Domain.UserData;

public sealed class User : IdentityUser<Guid>
{
    private User(string email, string login, string password, List<Role> roles)
    {
        Id = Guid.NewGuid();
        Email = email;
        Login = login;
        Password = password;

        Roles = roles;
    }

    public Guid Id { get; init; }
    public string Email { get; init; }
    public string Login { get; set; }
    public string Password { get; set; }

    public IEnumerable<Role> Roles { get; set; }
    public IEnumerable<Exercise> CreatedExercises { get; set; }
    public IEnumerable<ExerciseResolve> ResolvedExercises { get; set; }
}
