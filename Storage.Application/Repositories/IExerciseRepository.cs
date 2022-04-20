using Storage.Domain.ExerciseData;
using Storage.Domain.UserData;

namespace Storage.Application.Repositories;

public interface IExerciseRepository
{
    Task<List<Exercise>> GetExercisesByAuthorAsync(User author, CancellationToken cancellationToken);
    Task<List<Exercise>> GetAllExercisesAsync(CancellationToken cancellationToken);
    Task<Exercise?> GetExerciseByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateExerciseAsync(Exercise exercise, CancellationToken cancellationToken);
    void DeleteExercise(Exercise exercise);
    Task GetResolvesCount(Exercise exercise, CancellationToken cancellationToken);
    Task<List<Exercise>> GetExercisesByTitlePart(string titlePart, CancellationToken cancellationToken);
    Task SaveExerciseChangesAsync(CancellationToken cancellationToken);
}
