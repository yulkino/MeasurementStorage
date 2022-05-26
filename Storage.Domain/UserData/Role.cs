using Microsoft.AspNetCore.Identity;

namespace Storage.Domain.UserData;

public sealed class Role : IdentityRole<Guid>
{
    private Role(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public IEnumerable<User> Users { get; set; }
}
