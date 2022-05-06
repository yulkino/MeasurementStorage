namespace Storage.Application;

internal interface IResolveTimeMeasurer //TODO - implement
{
    Task<double> MeasureAsync(string resolve);
}
