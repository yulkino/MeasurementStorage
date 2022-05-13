using Storage.Domain.ExerciseData;

namespace Storage.Application; 

internal interface IResolveTimeMeasurer //TODO - implement
{
    Task<double> MeasureAsync(Exercise exercise, string resolve);
}
