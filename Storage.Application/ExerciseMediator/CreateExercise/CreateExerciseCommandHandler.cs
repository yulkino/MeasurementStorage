using MediatR;
using Storage.Application.Repositories;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.CreateExercise;

internal sealed class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, Exercise>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUserRepository _userRepository;

    public CreateExerciseCommandHandler(IExerciseRepository exerciseRepository, IUserRepository userRepository)
    {
        _exerciseRepository = exerciseRepository;
        _userRepository = userRepository;
    }

    public async Task<Exercise> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
    {
        var (title, description, authorId, creationDate) = request;

        var user = await _userRepository.GetUserByIdAsync(authorId, cancellationToken);
        if (user is null)
            throw new ArgumentException($"User with id {authorId} not found.");

        var exercise = new Exercise(title, description, user, creationDate);
        await _exerciseRepository.CreateExerciseAsync(exercise, cancellationToken);
        await _exerciseRepository.SaveExerciseChangesAsync(cancellationToken);

        return exercise;
    }
}
