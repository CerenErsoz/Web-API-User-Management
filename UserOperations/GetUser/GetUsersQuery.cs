using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.UserOperations.GetUsers
{
    public class GetUsersQuery
    {

        private readonly UserDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetUsersQuery(UserDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<UsersViewModel> Handle()
        {
            var userList = _dbContext.Users.OrderBy(x => x.Id).ToList<User>();
            List<UsersViewModel> vm = _mapper.Map<List<UsersViewModel>>(userList);
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

