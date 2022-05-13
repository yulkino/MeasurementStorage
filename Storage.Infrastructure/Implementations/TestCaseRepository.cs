using Storage.Application.Repositories;
using Storage.Domain.ExerciseData;
using Storage.Infrastructure.Data;

namespace Storage.Infrastructure.Implementations;

internal class TestCaseRepository : Repository, ITestCaseRepository
{
    public TestCaseRepository(ApplicationDbContext context) : base(context) { }

    public Task CreateTestCaseAsync(TestCase testCase, CancellationToken cancellationToken)
        => Context.TestCases.AddAsync(testCase, cancellationToken).AsTask();

    public Task DeleteTestCaseAsync(TestCase testCase, CancellationToken cancellationToken)
        => Task.FromResult(Context.TestCases.Remove(testCase));
}
