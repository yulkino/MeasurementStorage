using Storage.Domain.UserData;

namespace Storage.Domain.ExerciseData;

public sealed class Exercise
{
    public Exercise(string title, string description, User author, DateTime creationDate)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Author = author;
        CreationDate = creationDate;
    }

    public Guid Id { get; init; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IEnumerable<TestCase> TestCases { get; }
    public User Author { get; init; }
    public DateTime CreationDate { get; init; }

    public IEnumerable<ExerciseResolve> ExerciseResolves { get; set; }

    private Exercise() { }
}
