﻿namespace Storage.Application.ExerciseResolveMediator.GetConcreteExerciseResolveAndOtherVersionList;

public sealed record GetConcreteExerciseResolveAndOtherVersionListQuery(Guid UserId, Guid ExerciseId, DateTime CreationDate) : IOperation;
