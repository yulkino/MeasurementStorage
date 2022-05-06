using MediatR;
using Storage.Application.Repositories;

namespace Storage.Application.ExerciseMediator.DeleteExercise;

internal sealed class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand, Unit>
{
    private readonly IExerciseRepository _exerciseRepository;

    public DeleteExerciseCommandHandler(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<Unit> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
    {
        var exerciseId = request.ExerciseId;

        var exercise = await _exerciseRepository.GetExerciseByIdAsync(exerciseId, cancellationToken);
        if (exercise is null)
            throw new ArgumentException($"Exercise with id {exerciseId} not found");

        await _exerciseRepository.DeleteExerciseAsync(exercise);
        await _exerciseRepository.SaveExerciseChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
