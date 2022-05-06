using MediatR;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.GetExerciseListOfUser;

public record GetExerciseListOfUserQuery(Guid UserId) : IRequest<List<Exercise>>;
