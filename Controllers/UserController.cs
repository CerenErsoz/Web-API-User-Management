using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]

    public class UserController : ControllerBase
    {
        private static List<User> UserList = new List<User>()
        {
            new User
            {
                Id= 1,
                Name= "Ceren Ersoz",
                Email= "ersozceren2@gmail.com",
                Phone= "123456",
                Job= "Computer Engineer"
            },
            new User
            {
                Id= 2,
                Name= "Fatih Varol",
                Email= "f@gmail.com",
                Phone= "123456",
                Job= "Computer Engineer"
            },
            new User
            {
                Id= 3,
                Name = "Eleanor Johnson",
                Email = "eleanor.johnson@example.com",
                Phone = "+1234567890",
                Job = "Security Analyst"
            },
            new User
            {
                Id= 4,
                Name = "Liam Smith",
                Email = "liam.smith@example.com",
                Phone = "+9876543210",
                Job = "Data Analyst"
            },
            new User
            {
                Id= 5,
                Name= "Ceren Ceren",
                Email= "ersozceren2@gmail.com",
                Phone= "123456",
                Job= "Computer Engineer"
            },
        };


        [HttpGet]
        public IActionResult GetUsers()
        {
            var userList = UserList.OrderBy(x => x.Id).ToList<User>();
            if (userList.Any())
                return Ok(userList);
            else
                return NotFound(new { message = "No users found" });
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = UserList.Where(user => user.Id == id).SingleOrDefault();
            if (user is null)
                return NotFound(new { message = "No users found" });
            else
                return Ok(user);
        }



        //Filters usernames using nameFilter.
        //This example also allows listing like https://localhost:7291/Users/list?name=ceren
        [HttpGet("list")]
        public IActionResult GetProducts([FromQuery] string name)
        {
            var filteredProducts = UserList;

            if (!string.IsNullOrEmpty(name))
            {
                filteredProducts = filteredProducts
                    .Where(product => product.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (filteredProducts.Any())
                return Ok(filteredProducts);
            else
                return NotFound(new { message = "No products found" });
        }


        [HttpPost]
        public IActionResult AddUser([FromBody] User newUser)
        {
            var length = UserList.Count();
            newUser.Id = length;

            var user = UserList.SingleOrDefault(x => x.Name == newUser.Name);
            if (user is not null)
                return BadRequest("User already exists");

            UserList.Add(newUser);
            return Ok("New user added.");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromBody] User updateUser)
        {
            var user = UserList.SingleOrDefault(x => x.Id == updateUser.Id);
            if (user is null)
                return BadRequest("User not found.");

            user.Name = updateUser.Name != default ? updateUser.Name : user.Name;
            user.Email = updateUser.Email != default ? updateUser.Email : user.Email;
            user.Phone = updateUser.Phone != default ? updateUser.Phone : user.Phone;
            user.Job = updateUser.Job != default ? updateUser.Job : user.Job;

            return Ok("Successful");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {

            var user = UserList.SingleOrDefault(x => x.Id == id);
            if (user is null)
                return BadRequest("User not found.");

            UserList.Remove(user);
            return Ok("Successful");
        }


        [HttpPatch("{id}")]
        public IActionResult UpdateUserName(int id, [FromBody] string newName)
        {
            var user = UserList.SingleOrDefault(x => x.Id == id);
            if (user is null)
                return NotFound("User not found.");

            user.Name = newName;

            return Ok("Successful");
        }

    }
}

