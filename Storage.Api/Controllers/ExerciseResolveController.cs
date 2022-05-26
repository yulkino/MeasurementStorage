using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.Api.DTOs.ExerciseResolveDtos;
using Storage.Application.ExerciseResolveMediator.CreateExerciseResolve;
using Storage.Application.ExerciseResolveMediator.GetBetterExerciseResolveAndOtherVersionList;
using Storage.Application.ExerciseResolveMediator.GetConcreteExerciseResolveAndOtherVersionList;
using Storage.Application.ExerciseResolveMediator.GetExerciseResolveListOfUser;
using Storage.Application.Results;
using Storage.Domain.ExerciseData;

namespace Storage.Api.Controllers;

//TODO authorization

[ApiController]
[Route("[controller]")]
//[Authorize(Roles = "Default")]
public class ExerciseResolveController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ExerciseResolveController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    //todo check
    [HttpGet("{userid}/{exerciseId}/{sendingDate}")]
    public async Task<ActionResult<VersionControlExerciseResolvesDto>> GetConcreteExerciseResolveAndOtherVersions(
        [FromRoute] Guid userId, [FromRoute] Guid exerciseId, [FromRoute] DateTime sendingDate)
    {
        var query = new GetConcreteExerciseResolveAndOtherVersionListQuery(userId, exerciseId, sendingDate);
        var response = await _mediator.Send(query);
        return response switch
        {
            DoesNotExist doesNotExist => BadRequest(doesNotExist.Content),
            Success<(ExerciseResolve, List<ExerciseResolve>)> success => Ok(_mapper.Map<VersionControlExerciseResolvesDto>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    //todo check
    [HttpGet("{userid}/{exerciseId}")]
    public async Task<ActionResult<VersionControlExerciseResolvesDto>> GetBetterExerciseResolveAndOtherVersions(
        [FromRoute] Guid userId, [FromRoute] Guid exerciseId)
    {
        var query = new GetBetterExerciseResolveAndOtherVersionListQuery(userId, exerciseId);
        var response = await _mediator.Send(query);
        return response switch
        {
            DoesNotExist doesNotExist => BadRequest(doesNotExist.Content),
            Success<(ExerciseResolve, List<ExerciseResolve>)> success => Ok(_mapper.Map<VersionControlExerciseResolvesDto>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    //todo check
    [HttpGet("{userId}")]
    public async Task<ActionResult<List<ExerciseResolveDto>>> GetExerciseResolvesOfUser([FromRoute] Guid userId)
    {
        var query = new GetExerciseResolveListOfUserQuery(userId);
        var response = await _mediator.Send(query);
        return response switch
        {
            Success<List<ExerciseResolve>> success => Ok(_mapper.Map<List<ExerciseResolveDto>>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [HttpPost]
    public async Task<ActionResult<ExerciseResolveDto>> CreateExerciseResolve([FromBody] ExerciseResolveCreationDto exerciseResolveCreationDto)
    {
        var command = new CreateExerciseResolveCommand(exerciseResolveCreationDto.ExerciseId,
            exerciseResolveCreationDto.UserId, exerciseResolveCreationDto.Resolve,
            exerciseResolveCreationDto.SendingDate);
        var response = await _mediator.Send(command);
        return response switch
        {
            DoesNotExist doesNotExist => BadRequest(doesNotExist.Content),
            Created<ExerciseResolve> exerciseResolve => CreatedAtAction(nameof(CreateExerciseResolve),
                _mapper.Map<ExerciseResolveDto>(exerciseResolve.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }
}
