using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.Api.DTOs.RoleDtos;
using Storage.Api.DTOs.UserDtos;
using Storage.Application.Results;
using Storage.Application.RoleMediator.GetRoleList;
using Storage.Application.UserMediator.EditUserRole;
using Storage.Domain.UserData;

namespace Storage.Api.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Admin")]
public class RoleController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public RoleController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<RoleDto>>> GetRoles()
    {
        var query = new GetRoleListQuery();
        var response = await _mediator.Send(query);
        return response switch
        {
            Success<List<Role>> success => Ok(_mapper.Map<List<RoleDto>>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{userId}")]
    public async Task<ActionResult<UserDto>> EditUserRole([FromRoute] Guid userId, [FromBody] UserRoleDto role)
    {
        var command = new EditUserRoleCommand(userId, _mapper.Map<List<NewRole>>(role.Roles));
        var response = await _mediator.Send(command);
        return response switch
        {
            DoesNotExist doesNotExist => BadRequest(doesNotExist.Content),
            KeyIsOccupied keyIsOccupied => BadRequest(keyIsOccupied),
            Success<UserDto> success => Ok(_mapper.Map<UserDto>(success.Content)),
            _ => throw new ArgumentException("Unexpected result")
        };
    }
}
