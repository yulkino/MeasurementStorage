﻿namespace Storage.Application.ExerciseResolveMediator.GetBetterExerciseResolveAndOtherVersionList;

public sealed record GetBetterExerciseResolveAndOtherVersionListQuery(Guid UserId, Guid ExerciseId) : IOperation;
