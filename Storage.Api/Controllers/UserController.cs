﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.Api.DTOs.UserDtos;

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

    [Authorize(Roles = "Admin")]
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
