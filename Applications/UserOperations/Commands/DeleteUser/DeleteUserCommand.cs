using WebApi.DBOperations;

namespace WebApi.Applications.UserOperations.Commands.DeleteUser
{
    public class DeleteUserCommand
    {
        private readonly IUserDbContext _context;
        public int UserId { get; set; }
        public DeleteUserModel Model { get; set; }

        public DeleteUserCommand(IUserDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == UserId);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

    public class DeleteUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Job { get; set; }
    }

}