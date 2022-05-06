using MediatR;
using Storage.Application.Repositories;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.EditExercise;

internal sealed class EditExerciseCommandHandler : IRequestHandler<EditExerciseCommand, Exercise>
{
    private readonly IExerciseRepository _exerciseRepository;

    public EditExerciseCommandHandler(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<Exercise> Handle(EditExerciseCommand request, CancellationToken cancellationToken)
    {
        var (exerciseId, newTitle, newDescription)  = request;

        var exercise = await _exerciseRepository.GetExerciseByIdAsync(exerciseId, cancellationToken);
        if (exercise is null)
            throw new ArgumentException($"Exercise with id {exerciseId} not found");

        exercise.Title = newTitle;
        exercise.Description = newDescription;
        await _exerciseRepository.SaveExerciseChangesAsync(cancellationToken);

        return exercise;
    }
}
