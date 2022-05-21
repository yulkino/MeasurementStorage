using MediatR;
using Storage.Application.Results;

namespace Storage.Application;

internal interface IOperationHandler<in T> : IRequestHandler<T, OperationResult>
    where T : IOperation
{ }
