using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.Api.DTOs.UserDtos;
using Storage.Application.Results;
using Storage.Application.UserMediator.CreateUser;
using Storage.Domain.UserData;

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

    [Authorize(Roles = "Admin")]
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
    public async Task<ActionResult<UserDto>> Login([FromRoute] UserLoginDto userLoginDto)
    {

    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserCreationDto user)
    {
        var command = new CreateUserCommand(user.Login, user.Email, user.Password);
        var response = await _mediator.Send(command);
        return response switch
        {
            KeyIsOccupied keyIsOccupied => BadRequest(keyIsOccupied.Content),
            Created<User> created => CreatedAtAction(nameof(CreateUser), _mapper.Map<UserDto>(created.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteUser([FromRoute] Guid userId)
    {

    }

    [HttpPut]
    public async Task<ActionResult<UserDto>> EditUser([FromRoute] Guid userId, [FromBody] UserLoginDto user)
    {

    }

    [HttpGet]
    public async Task<ActionResult<List<ShortUserDto>>> GetUsersByEmailOrLoginPart([FromRoute] string textPart)
    {

    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UserDto>> EditUserRole([FromRoute] Guid userId, [FromBody] UserRoleDto role)
    {

    }
}
