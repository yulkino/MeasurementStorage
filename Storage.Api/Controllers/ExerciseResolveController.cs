using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.Api.DTOs.ExerciseResolveDtos;
using Storage.Application.ExerciseResolveMediator.CreateExerciseResolve;
using Storage.Application.ExerciseResolveMediator.GetExerciseResolveListOfUser;
using Storage.Application.Results;
using Storage.Domain.ExerciseData;

namespace Storage.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Default")]
public class ExerciseResolveController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ExerciseResolveController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    //todo контроллер, который по userId exerciseId DateTIme будет отдавать ExerciseResolve

    [HttpGet("/{userId}")]
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
        var command = new CreateExerciseResolveCommand(exerciseResolveCreationDto.Exercise.Id,
            exerciseResolveCreationDto.User.Id, exerciseResolveCreationDto.Resolve,
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
