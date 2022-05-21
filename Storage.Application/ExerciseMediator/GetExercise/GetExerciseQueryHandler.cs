using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.GetExercise;

internal sealed class GetExerciseHandler : IOperationHandler<GetExerciseQuery>
{
    private readonly IExerciseRepository _exerciseRepository;

    public GetExerciseHandler(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<OperationResult> Handle(GetExerciseQuery request, CancellationToken cancellationToken)
    {
        var exerciseId = request.ExerciseId;
        var exercise = await _exerciseRepository.GetExerciseByIdAsync(exerciseId, cancellationToken);
        if (exercise is null)
            return new DoesNotExist($"Exercise with id {exerciseId} not found");

        return new Success<Exercise>(exercise);
    }
}
