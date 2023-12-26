using Microsoft.AspNetCore.Mvc;
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
        public UserController(UserDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            GetUsersQuery getUsersQuery = new GetUsersQuery(_context);
            var result = getUsersQuery.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetUserDetailQuery query = new GetUserDetailQuery(_context);
            query.UserId = id;
            query.Handle();
            return Ok();

        }


        [HttpPost]
        public IActionResult AddUser([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context);
            command.Model = newUser;
            command.Handle();
            return Ok();
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
            command.Handle();
            return Ok();
        }
    }
}

