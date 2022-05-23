using Microsoft.EntityFrameworkCore;
using Storage.Application.Repositories;
using Storage.Domain.ExerciseData;
using Storage.Domain.UserData;
using Storage.Infrastructure.Data;

namespace Storage.Infrastructure.Implementations;

internal class ExerciseRepository : Repository, IExerciseRepository
{
    public ExerciseRepository(ApplicationDbContext context) : base(context) { }

    public Task CreateExerciseAsync(Exercise exercise, CancellationToken cancellationToken)
        => Context.Exercises.AddAsync(exercise, cancellationToken).AsTask();

    public Task DeleteExerciseAsync(Exercise exercise, CancellationToken cancellationToken)
        => Task.FromResult(Context.Exercises.Remove(exercise));

    public Task<List<Exercise>> GetAllExercisesAsync(CancellationToken cancellationToken)
        => Context.Exercises.ToListAsync(cancellationToken);

    public Task<List<Exercise>> GetExercisesByAuthorAsync(User author, CancellationToken cancellationToken)
        => Context.Exercises.Where(e => e.Author == author).ToListAsync(cancellationToken);

    public Task<Exercise?> GetExerciseByIdAsync(Guid id, CancellationToken cancellationToken)
        => Context.Exercises.FindAsync(id, cancellationToken).AsTask();

    public Task<int> GetResolvesCount(Exercise exercise, CancellationToken cancellationToken)
        => Context.ExercisesResolves.Where(e => e.Exercise == exercise).CountAsync(cancellationToken);

    public Task<List<Exercise>> GetExercisesByTitlePart(string titlePart, CancellationToken cancellationToken)
        => Context.Exercises.Where(e => e.Title.Contains(titlePart)).ToListAsync(cancellationToken);
}
