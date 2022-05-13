using MediatR;
using Storage.Application.Results;

namespace Storage.Application;

internal interface IOperation : IRequest<OperationResult> { }
