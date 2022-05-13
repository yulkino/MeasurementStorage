namespace Storage.Application.Results;

public abstract record OperationResult();
public sealed record WithoutContent() : OperationResult;

public abstract record ContentResult<T>(T Content) : OperationResult;
public sealed record Success<T>(T Content) : ContentResult<T>(Content);
public sealed record Created<T>(T Content) : ContentResult<T>(Content);

public sealed record Error(string ErrorMessage);
public abstract record BadResult(string ErrorMessage) : ContentResult<Error>(new Error(ErrorMessage));
public sealed record DoesNotExist(string ErrorMessage) : BadResult(ErrorMessage);
public sealed record KeyIsOccupied(string ErrorMessage) : BadResult(ErrorMessage);