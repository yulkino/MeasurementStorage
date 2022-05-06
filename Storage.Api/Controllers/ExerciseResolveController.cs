using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.Api.DTOs.ExerciseResolveDtos;

namespace Storage.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Default")]
public class ExerciseResolveController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UserController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ExerciseResolveDto>>> GetExerciseResolvesOfUser([FromRoute] Guid userId)
    {

    }

    [HttpPost]
    public async Task<ActionResult<ExerciseResolveDto>> CreateExerciseResolve([FromBody] ExerciseResolveCreationDto exerciseResolveCreationDto)
    {

    }
}
