using MediatR;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.GetExerciseLeaderBoard;

public record GetExerciseLeaderBoardQuery(Guid ExerciseId) : IRequest<Exercise>;
