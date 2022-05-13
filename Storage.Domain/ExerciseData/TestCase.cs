namespace Storage.Domain.ExerciseData;

public sealed class TestCase
{
    public TestCase(Exercise exercise, string input, string output)
    {
        Id = Guid.NewGuid();
        Exercise = exercise;
        Input = input;
        Output = output;
    }

    public Guid Id { get; init; }
    public Exercise Exercise { get; set; }
    public string Input { get; set; }
    public string Output { get; set; }

    private TestCase() { }

    public string GetErrorMessage(string incorrectOutput)
        => $"При входных данных {{{Input}}}, программа должна была вывести {{{Output}}}, а вывела {{{incorrectOutput}}}";
}
