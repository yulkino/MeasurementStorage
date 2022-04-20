namespace Storage.Domain.UserData;

public sealed class Role
{
    public Guid Id { get; init; }
    public string Name { get; init; }

    private Role(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public IEnumerable<User> Users { get; set; }
}
