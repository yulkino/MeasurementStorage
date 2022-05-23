using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.Api.DTOs.ExerciseDtos;
using Storage.Api.DTOs.UserDtos;
using Storage.Application.ExerciseMediator.GetExerciseListOfUser;
using Storage.Application.Results;
using Storage.Application.UserMediator.CreateUser;
using Storage.Application.UserMediator.DeleteUser;
using Storage.Application.UserMediator.EditUser;
using Storage.Application.UserMediator.EditUserRole;
using Storage.Application.UserMediator.GetUser;
using Storage.Application.UserMediator.GetUserList;
using Storage.Application.UserMediator.GetUserListByEmailOrLoginPart;
using Storage.Application.UserMediator.LoginUser;
using Storage.Domain.ExerciseData;
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
        var query = new GetUserListQuery();
        var response = await _mediator.Send(query);
        return response switch
        {
            Success<List<ShortUserDto>> success => Ok(_mapper.Map<List<ShortUserDto>>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<UserDto>> GetUser([FromRoute] Guid userId)
    {
        var query = new GetUserQuery(userId);
        var response = await _mediator.Send(query);
        return response switch
        {
            DoesNotExist doesNotExist => BadRequest(doesNotExist.Content),
            Success<User> success => Ok(_mapper.Map<UserDto>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [AllowAnonymous]
    [HttpGet("Login")]
    public async Task<ActionResult<UserDto>> Login([FromBody] UserLoginDto userLoginDto)
    {
        var query = new LoginUserQuery(userLoginDto.Login, userLoginDto.Password);
        var response = await _mediator.Send(query);
        return response switch
        {
            DoesNotExist doesNotExist => BadRequest(doesNotExist.Content),
            PasswordDoesNotExist passwordDoesNotExist => BadRequest(passwordDoesNotExist.Content),
            Success<User> success => Ok(_mapper.Map<UserDto>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
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


    [Authorize(Roles = "Admin")]
    [HttpDelete("{userId}")]
    public async Task<ActionResult> DeleteUser([FromRoute] Guid userId)
    {
        var command = new DeleteUserCommand(userId);
        var response = await _mediator.Send(command);
        return response switch
        {
            DoesNotExist doesNotExist => BadRequest(doesNotExist.Content),
            WithoutContent withoutContent => NoContent(),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [HttpPut("{userId}")]
    public async Task<ActionResult<UserDto>> EditUser([FromRoute] Guid userId, [FromBody] UserEditionDto user)
    {
        var command = new EditUserCommand(userId, user.Login, user.Password, user.AvatarUrl);
        var response = await _mediator.Send(command);
        return response switch
        {
            DoesNotExist doesNotExist => BadRequest(doesNotExist.Content),
            Success<User> success => Ok(_mapper.Map<UserDto>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [HttpGet("{textPart}")]
    public async Task<ActionResult<List<ShortUserDto>>> GetUsersByEmailOrLoginPart([FromRoute] string textPart)
    {
        var query = new GetUserListByEmailOrLoginPartQuery(textPart);
        var response = await _mediator.Send(query);
        return response switch
        {
            Success<List<User>> success => Ok(_mapper.Map<List<UserDto>>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [HttpGet("{userId}/Exercises")]
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
}
