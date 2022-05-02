using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.Api.DTOs.Exercise;

namespace Storage.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Editor")]
public class ExerciseController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UserController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "Default")]
    public async Task<ActionResult<List<ExerciseDto>>> GetExercises()
    {

    }

    [HttpGet]
    [Authorize(Roles = "Default")]
    public async Task<ActionResult<ExerciseDto>> GetExercise([FromRoute] Guid exerciseId)
    {

    }

    [HttpGet]
    public async Task<ActionResult<ExerciseDto>> GetExercisesOfUser([FromRoute] Guid userId)
    {

    }

    [HttpPost]
    public async Task<ActionResult<ExerciseDto>> CreateExercise([FromBody] ExerciseCreationDto requestExerciseDto)
    {

    }

    [HttpPut]
    public async Task<ActionResult<ExerciseDto>> EditExercise([FromRoute] Guid exerciseId, [FromBody] ExerciseEditionDto exerciseEditionDto)
    {

    }

    [HttpDelete]
    public async Task<ActionResult> DeleteExercise([FromRoute] Guid exerciseId)
    {

    }

    [HttpGet]
    public async Task<ActionResult> GetExerciseLeaderBoard([FromRoute] Guid exerciseResolveId)
    {

    }

    [HttpGet]
    public async Task<ActionResult> GetExerciseStatistics([FromRoute] Guid exerciseResolveId)
    {

    }
}
