using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly UserDBContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserCommand(UserDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Name == Model.Name);
            user = _mapper.Map<User>(Model);//Model ile gelen veriyi User objesine ekle
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