using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.Api.DTOs.User;

namespace Storage.Api.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Default")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UserController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ShortUserDto>>> GetUsers()
    {

    }

    [HttpGet]
    public async Task<ActionResult<UserDto>> GetUser([FromRoute] Guid id)
    {

    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<UserDto>> GetUser([FromRoute] string login)
    {

    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserCreationDto user)
    {

    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteUser([FromRoute] Guid userId)
    {

    }

    [HttpPut]
    public async Task<ActionResult<UserDto>> EditUser([FromRoute] Guid userId, [FromBody] UserEditionDto user)
    {

    }

    [HttpGet]
    public async Task<ActionResult<List<ShortUserDto>>> GetUsersByEmailOrLoginPart([FromRoute] string textPart)
    {

    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UserDto>> UserRoleEdit([FromRoute] Guid userId, [FromBody] UserRoleDto role)
    {

    }
}
