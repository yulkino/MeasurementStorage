﻿namespace Storage.Application.ExerciseResolveMediator.CreateExerciseResolve;

public record CreateExerciseResolveCommand(
    Guid ExerciseId,
    Guid UserId,
    string Resolve,
    DateTime SendingDate) : IOperation;
