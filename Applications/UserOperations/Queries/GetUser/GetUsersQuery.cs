using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Applications.UserOperations.Queries.GetUsers
{
    public class GetUsersQuery
    {
        private readonly IUserDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUsersQuery(IUserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<UsersViewModel> Handle()
        {
            var userList = _dbContext.Users.Include(x => x.Job).OrderBy(x => x.Id).ToList<User>();
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

