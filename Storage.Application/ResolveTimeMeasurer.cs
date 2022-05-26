using Storage.Domain.ExerciseData;

namespace Storage.Application;

internal class ResolveTimeMeasurer : IResolveTimeMeasurer
{
    public Task<double> MeasureAsync(Exercise exercise, string resolve)
    {
        return Task.FromResult(69.420);
    }
}
