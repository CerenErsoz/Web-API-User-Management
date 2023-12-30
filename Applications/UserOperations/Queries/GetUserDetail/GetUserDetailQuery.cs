using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Applications.UserOperations.Queries.GetUserDetailQuery
{
    public class GetUserDetailQuery
    {
        private readonly UserDBContext _dbContext;
        private readonly IMapper _mapper;
        public int UserId { get; set; }
        public GetUserDetailQuery(UserDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserDetailViewModel Handle()
        {
            var user = _dbContext.Users.Include(x => x.Job).Where(user => user.Id == UserId).SingleOrDefault();
            if (user is null)
                throw new InvalidOperationException("User is not valid.");
            UserDetailViewModel vm = _mapper.Map<UserDetailViewModel>(user);
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