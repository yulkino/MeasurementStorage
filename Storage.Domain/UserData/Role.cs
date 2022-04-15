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

    public static readonly Role Default = new("Default");
    public static readonly Role Editor = new("Editor");
    public static readonly Role Admin = new("Admin");
}
