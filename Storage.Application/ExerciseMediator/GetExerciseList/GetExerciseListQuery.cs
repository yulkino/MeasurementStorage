using MediatR;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.GetExerciseList;

public record GetExerciseListQuery : IRequest<List<Exercise>>;
