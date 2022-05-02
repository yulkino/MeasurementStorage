using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.Api.DTOs.Role;

namespace Storage.Api.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("[controller]")]
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
    public async Task<List<RoleDto>> GetRoles()
    {

    }
}
