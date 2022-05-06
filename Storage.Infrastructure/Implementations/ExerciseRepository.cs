using Microsoft.EntityFrameworkCore;
using Storage.Application.Repositories;
using Storage.Domain.ExerciseData;
using Storage.Domain.UserData;
using Storage.Infrastructure.Data;

namespace Storage.Infrastructure.Implementations;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationDbContext _context;

    public ExerciseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task CreateExerciseAsync(Exercise exercise, CancellationToken cancellationToken)
        => _context.Exercises.AddAsync(exercise, cancellationToken).AsTask();

    public Task DeleteExerciseAsync(Exercise exercise)
        => Task.FromResult(_context.Exercises.Remove(exercise));

    public Task<List<Exercise>> GetAllExercisesAsync(CancellationToken cancellationToken)
        => _context.Exercises.ToListAsync(cancellationToken);

    public Task<List<Exercise>> GetExercisesByAuthorAsync(User author, CancellationToken cancellationToken)
        => _context.Exercises.Where(e => e.Author == author).ToListAsync(cancellationToken);

    public Task<Exercise?> GetExerciseByIdAsync(Guid id, CancellationToken cancellationToken)
        => _context.Exercises.FindAsync(id, cancellationToken).AsTask();

    public Task SaveExerciseChangesAsync(CancellationToken cancellationToken)
        => _context.SaveChangesAsync(cancellationToken);

    public Task GetResolvesCount(Exercise exercise, CancellationToken cancellationToken)
        => _context.ExercisesResolves.Where(e => e.Exercise == exercise).CountAsync(cancellationToken);

    public Task<List<Exercise>> GetExercisesByTitlePart(string titlePart, CancellationToken cancellationToken)
        => _context.Exercises.Where(e => e.Title.Contains(titlePart)).ToListAsync(cancellationToken);
}
