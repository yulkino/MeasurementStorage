using MediatR;
using Storage.Application.Repositories;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.GetExercise;

internal sealed class GetExerciseHandler : IRequestHandler<GetExerciseQuery, Exercise>
{
    private readonly IExerciseRepository _exerciseRepository;

    public GetExerciseHandler(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<Exercise> Handle(GetExerciseQuery request, CancellationToken cancellationToken)
    {
        var exerciseId = request.ExerciseId;
        var exercise = await _exerciseRepository.GetExerciseByIdAsync(exerciseId, cancellationToken);
        if (exercise is null)
            throw new ArgumentException($"Exercise with id {exerciseId} not found");

        return exercise;
    }
}
