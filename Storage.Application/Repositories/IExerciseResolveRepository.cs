using Storage.Domain.ExerciseData;
using Storage.Domain.UserData;

namespace Storage.Application.Repositories;

public interface IExerciseResolveRepository
{
    Task<List<ExerciseResolve>> GetExerciseResolvesByUserAsync(User user, CancellationToken cancellationToken);
    Task<ExerciseResolve?> GetExerciseResolvesByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateExerciseResolveAsync(ExerciseResolve exerciseResolve, CancellationToken cancellationToken);
    Task SaveExerciseResolveChangesAsync(CancellationToken cancellationToken);
}
