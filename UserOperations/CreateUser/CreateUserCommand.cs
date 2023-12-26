using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.UserOperations.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly UserDBContext _dbContext;

        public CreateUserCommand(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Name == Model.Name);

            user = new User();
            user.Name = Model.Name;
            user.Email = Model.Email;
            user.Phone = Model.Phone;
            user.JobId = Model.Job;

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }


        public class CreateUserModel
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public int Job { get; set; }
        }

    }
}