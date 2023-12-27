﻿using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.DBOperations;
using WebApi.UserOperations.CreateUser;
using WebApi.UserOperations.DeleteUser;
using WebApi.UserOperations.GetUserDetailQuery;
using WebApi.UserOperations.GetUsers;
using WebApi.UserOperations.UpdateUser;
using static WebApi.UserOperations.CreateUser.CreateUserCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]

    public class UserController : ControllerBase
    {
        private readonly UserDBContext _context;
        private readonly IMapper _mapper;


        public UserController(UserDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            GetUsersQuery getUsersQuery = new GetUsersQuery(_context, _mapper);
            var result = getUsersQuery.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetUserDetailQuery query = new GetUserDetailQuery(_context, _mapper);
            query.UserId = id;
            var result = query.Handle();
            return Ok(result);

        }


        [HttpPost]
        public IActionResult AddUser([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = newUser;
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok(newUser);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserModel updateUser)
        {
            UpdateUserCommand command = new UpdateUserCommand(_context);
            command.UserId = id;
            command.Model = updateUser;
            command.Handle();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            DeleteUserCommand command = new DeleteUserCommand(_context);
            command.UserId = id;
            DeleteUserCommandValidator validator = new DeleteUserCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}