using Storage.Domain.UserData;

namespace Storage.Domain.ExerciseData;

public sealed class ExerciseResolve
{
    public ExerciseResolve(Exercise exercise, User user, string resolve, DateTime sendingDate, double executionTime)
    {
        Id = Guid.NewGuid();
        Exercise = exercise;
        User = user;
        Resolve = resolve;
        SendingDate = sendingDate;
        ExecutionTime = executionTime;
    }

    public Guid Id { get; init; }
    public Exercise Exercise { get; init; }
    public User User { get; init; }
    public string Resolve { get; init; }
    public DateTime SendingDate { get; init; }
    public double ExecutionTime { get; init; }

    private ExerciseResolve() { }
}
