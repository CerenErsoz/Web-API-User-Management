
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.UserOperations.GetUsers
{

    public class GetUsersQuery
    {

        private readonly UserDBContext _dbContext;

        public GetUsersQuery(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UsersViewModel> Handle()
        {
            var userList = _dbContext.Users.OrderBy(x => x.Id).ToList<User>();
            List<UsersViewModel> vm = new List<UsersViewModel>();
            foreach (var user in userList)
            {
                vm.Add(new UsersViewModel()
                {
                    Name = user.Name,
                    Job = ((JobEnum)user.JobId).ToString(),
                    Phone = user.Phone,
                    Email = user.Email
                });
            }
            return vm;

        }

    }



    public class UsersViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Job { get; set; }
    }

}

