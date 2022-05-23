namespace Storage.Application.ExerciseResolveMediator.CreateExerciseResolve;

public sealed record CreateExerciseResolveCommand(
    Guid ExerciseId,
    Guid UserId,
    string Resolve,
    DateTime SendingDate) : IOperation;
