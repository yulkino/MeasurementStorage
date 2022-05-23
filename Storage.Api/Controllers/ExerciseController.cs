using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.Api.DTOs.Exercise;
using Storage.Api.DTOs.ExerciseDtos;
using Storage.Application.DTOs;
using Storage.Application.ExerciseMediator.CreateExercise;
using Storage.Application.ExerciseMediator.DeleteExercise;
using Storage.Application.ExerciseMediator.EditExercise;
using Storage.Application.ExerciseMediator.GetExercise;
using Storage.Application.ExerciseMediator.GetExerciseLeaderBoard;
using Storage.Application.ExerciseMediator.GetExerciseList;
using Storage.Application.ExerciseMediator.GetExerciseListOfUser;
using Storage.Application.ExerciseMediator.GetExerciseStatistics;
using Storage.Application.Results;
using Storage.Domain.ExerciseData;

namespace Storage.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Editor")]
public class ExerciseController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ExerciseController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "Default")]
    public async Task<ActionResult<List<ShortExerciseDto>>> GetExercises()
    {
        var query = new GetExerciseListQuery();
        var response = await _mediator.Send(query);
        return response switch
        {
            Success<List<(Exercise, int)>> success => Ok(_mapper.Map<List<ShortExerciseDto>>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [HttpGet("/{exerciseId}")]
    [Authorize(Roles = "Default")]
    public async Task<ActionResult<ExerciseDto>> GetExercise([FromRoute] Guid exerciseId)
    {
        var query = new GetExerciseQuery(exerciseId);
        var response = await _mediator.Send(query);
        return response switch
        {
            DoesNotExist doesNotExist => BadRequest(doesNotExist.Content),
            Success<Exercise> success => Ok(_mapper.Map<ExerciseDto>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [HttpGet("/{userId}")]
    public async Task<ActionResult<ExerciseDto>> GetExercisesOfUser([FromRoute] Guid userId)
    {
        var query = new GetExerciseListOfUserQuery(userId);
        var response = await _mediator.Send(query);
        return response switch
        {
            DoesNotExist doesNotExist => BadRequest(doesNotExist.Content),
            Success<List<Exercise>> success => Ok(_mapper.Map<ExerciseDto>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [HttpPost]
    public async Task<ActionResult<ExerciseDto>> CreateExercise([FromBody] ExerciseCreationDto requestExerciseDto)
    {
        var command = new CreateExerciseCommand(requestExerciseDto.Title, requestExerciseDto.Description,
            _mapper.Map<List<TestCaseApplicationDto>>(requestExerciseDto.TestCases), requestExerciseDto.Author.Id, requestExerciseDto.CreationDate);
        var response = await _mediator.Send(command);
        return response switch
        {
            DoesNotExist doesNotExist => BadRequest(doesNotExist.Content),
            Created<Exercise> created => CreatedAtAction(nameof(CreateExercise), _mapper.Map<ExerciseDto>(created.Content)),
            //todo дописть варианты после реализации замера времени работы кода 
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [HttpPut("/{exerciseId}")]
    public async Task<ActionResult<ExerciseDto>> EditExercise([FromRoute] Guid exerciseId, [FromBody] ExerciseEditionDto exerciseEditionDto)
    {
        var command = new EditExerciseCommand(exerciseId, exerciseEditionDto.Title, exerciseEditionDto.Description,
            _mapper.Map<List<TestCaseApplicationDto>>(exerciseEditionDto.TestCases));
        var response = await _mediator.Send(command);
        return response switch
        {
            DoesNotExist doesNotExist => BadRequest(doesNotExist.Content),
            Success<Exercise> success => Ok(_mapper.Map<ExerciseDto>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [HttpDelete("/{exerciseId}")]
    public async Task<ActionResult> DeleteExercise([FromRoute] Guid exerciseId)
    {
        var command = new DeleteExerciseCommand(exerciseId);
        var response = await _mediator.Send(command);
        return response switch
        {
            DoesNotExist doesNotExist => BadRequest(doesNotExist.Content),
            WithoutContent withoutContent => NoContent(),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [Authorize(Roles = "Default")]
    [HttpGet("/{exerciseId}")]
    public async Task<ActionResult> GetExerciseLeaderBoard([FromRoute] Guid exerciseId)
    {
        var query = new GetExerciseLeaderBoardQuery(exerciseId);
        var response = await _mediator.Send(query);
        return response switch
        {
            //todo return
        };
    }

    [Authorize(Roles = "Default")]
    [HttpGet("/{exerciseId}")]
    public async Task<ActionResult> GetExerciseStatistics([FromRoute] Guid exerciseId)
    {
        var query = new GetExerciseStatisticsQuery(exerciseId);
        var response = await _mediator.Send(query);
        return response switch
        {
            //todo return
        };
    }
}
