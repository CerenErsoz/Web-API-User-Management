

using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.UserOperations.GetUserDetailQuery
{
    public class GetUserDetailQuery
    {

        private readonly UserDBContext _dbContext;
        public int UserId { get; set; }
        public GetUserDetailQuery(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserDetailViewModel Handle()
        {
            var user = _dbContext.Users.Where(user => user.Id == UserId).SingleOrDefault();
            UserDetailViewModel vm = new UserDetailViewModel();
            vm.Name = user.Name;
            vm.Email = user.Email;
            vm.Phone = user.Phone;
            vm.Job = ((JobEnum)user.JobId).ToString();
            return vm;
        }


    }

    public class UserDetailViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Job { get; set; }
    }


}