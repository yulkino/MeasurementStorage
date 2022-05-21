using Storage.Application.Repositories;
using Storage.Application.Results;

namespace Storage.Application.ExerciseMediator.DeleteExercise;

internal sealed class DeleteExerciseCommandHandler : IOperationHandler<DeleteExerciseCommand>
{
    private readonly IExerciseRepository _exerciseRepository;

    public DeleteExerciseCommandHandler(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<OperationResult> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
    {
        var exerciseId = request.ExerciseId;

        var exercise = await _exerciseRepository.GetExerciseByIdAsync(exerciseId, cancellationToken);
        if (exercise is null)
            return new DoesNotExist($"Exercise with id {exerciseId} not found");

        await _exerciseRepository.DeleteExerciseAsync(exercise, cancellationToken);
        await _exerciseRepository.SaveChangesAsync(cancellationToken);

        return new WithoutContent();
    }
}
