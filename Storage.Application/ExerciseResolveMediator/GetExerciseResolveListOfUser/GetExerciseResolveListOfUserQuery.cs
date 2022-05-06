using MediatR;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseResolveMediator.GetExerciseResolveListOfUser;

public sealed record GetExerciseResolveListOfUserQuery(Guid UserId) : IRequest<List<ExerciseResolve>>;
