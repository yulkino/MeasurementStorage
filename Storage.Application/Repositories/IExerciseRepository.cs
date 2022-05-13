using Storage.Domain.ExerciseData;
using Storage.Domain.UserData;

namespace Storage.Application.Repositories;

public interface IExerciseRepository : IRepository
{
    Task<List<Exercise>> GetExercisesByAuthorAsync(User author, CancellationToken cancellationToken);
    Task<List<Exercise>> GetAllExercisesAsync(CancellationToken cancellationToken);
    Task<Exercise?> GetExerciseByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateExerciseAsync(Exercise exercise, CancellationToken cancellationToken);
    Task DeleteExerciseAsync(Exercise exercise, CancellationToken cancellationToken);
    Task GetResolvesCount(Exercise exercise, CancellationToken cancellationToken);
    Task<List<Exercise>> GetExercisesByTitlePart(string titlePart, CancellationToken cancellationToken);
}
