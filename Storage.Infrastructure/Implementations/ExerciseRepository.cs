using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Storage.Application.Repositories;
using Storage.Domain.ExerciseData;
using Storage.Domain.UserData;
using Storage.Infrastructure.Data;

namespace Storage.Infrastructure.Implementations;

internal class ExerciseRepository : Repository, IExerciseRepository
{
    private readonly IQueryable<Exercise> _exercisesWithTestCases;

    public ExerciseRepository(ApplicationDbContext context) : base(context)
    {
        _exercisesWithTestCases = Context.Exercises.Include(e => e.TestCases);
    }

    public Task CreateExerciseAsync(Exercise exercise, CancellationToken cancellationToken)
        => Context.Exercises.AddAsync(exercise, cancellationToken).AsTask();

    public Task DeleteExerciseAsync(Exercise exercise, CancellationToken cancellationToken)
        => Task.FromResult(Context.Exercises.Remove(exercise));

    public Task<List<Exercise>> GetAllExercisesAsync(CancellationToken cancellationToken)
        => Context.Exercises.ToListAsync(cancellationToken);

    public Task<List<Exercise>> GetExercisesByAuthorAsync(User author, CancellationToken cancellationToken)
        => Context.Exercises.Where(e => e.Author == author).ToListAsync(cancellationToken);

    public Task<Exercise?> GetExerciseByIdAsync(Guid id, CancellationToken cancellationToken)
        => _exercisesWithTestCases.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    public Task<int> GetResolvesCount(Exercise exercise, CancellationToken cancellationToken)
        => Context.ExercisesResolves.Where(e => e.Exercise == exercise).CountAsync(cancellationToken);

    public Task<List<Exercise>> GetExercisesByTitlePart(string titlePart, CancellationToken cancellationToken)
        => Context.Exercises.Where(e => e.Title.Contains(titlePart)).ToListAsync(cancellationToken);
}
