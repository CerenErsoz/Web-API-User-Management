using WebApi.DBOperations;

namespace WebApi.Applications.UserOperations.Commands.UpdateUser
{
    public class UpdateUserCommand
    {
        private readonly IUserDbContext _context;
        public int UserId { get; set; }

        public UpdateUserModel Model { get; set; }

        public UpdateUserCommand(IUserDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == UserId);
            user.Name = Model.Name != default ? Model.Name : user.Name;
            user.JobId = Model.Job != default ? Model.Job : user.JobId;
            _context.SaveChanges();
        }
    }

    public class UpdateUserModel
    {
        public string Name { get; set; }
        public int Job { get; set; }
    }

}