using AutoMapper;
using WebApi.UserOperations.GetUserDetailQuery;
using WebApi.UserOperations.GetUsers;
using static WebApi.UserOperations.CreateUser.CreateUserCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserModel, User>();
            CreateMap<User, UserDetailViewModel>().ForMember(dest => dest.Job, opt => opt.MapFrom(src => ((JobEnum)src.JobId).ToString()));
            CreateMap<User, UsersViewModel>().ForMember(dest => dest.Job, opt => opt.MapFrom(src => ((JobEnum)src.JobId).ToString()));
        }
    }
}