namespace Storage.Domain.ExerciseData;

public sealed class TestCase //todo описание ошибки 
{
    public TestCase(Exercise exercise, string input, string output)
    {
        Id = Guid.NewGuid();
        Exercise = exercise;
        Input = input;
        Output = output;
    }

    public Guid Id { get; init; }
    public Exercise Exercise { get; }
    public string Input { get; }
    public string Output { get; }
}
