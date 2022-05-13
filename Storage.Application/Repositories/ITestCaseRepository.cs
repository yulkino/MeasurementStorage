using Storage.Domain.ExerciseData;

namespace Storage.Application.Repositories;

public interface ITestCaseRepository : IRepository
{
    Task CreateTestCaseAsync(TestCase testCase, CancellationToken cancellationToken);
    Task DeleteTestCaseAsync(TestCase testCase, CancellationToken cancellationToken);
}
