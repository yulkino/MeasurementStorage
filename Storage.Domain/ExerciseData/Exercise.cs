using Storage.Domain.UserData;

namespace Storage.Domain.ExerciseData;

public sealed class Exercise
{
    public Exercise(string title, string description, string inputData, string outputData, User author, DateTime creationDate)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        InputData = inputData;
        OutputData = outputData;
        Author = author;
        CreationDate = creationDate;
    }

    public Guid Id { get; init; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string InputData { get; set; }
    public string OutputData { get; set; }
    public User Author { get; init; }
    public DateTime CreationDate { get; init; }

    public IEnumerable<ExerciseResolve> ExerciseResolves { get; set; }

    private Exercise() { }
}
