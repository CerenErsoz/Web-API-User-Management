using AutoMapper;
using WebApi.Applications.UserOperations.Queries.GetUserDetailQuery;
using WebApi.Applications.UserOperations.Queries.GetUsers;
using WebApi.Entities;
using static WebApi.Applications.JobOperations.Queries.GetJobDetail.GetJobDetailQuery;
using static WebApi.Applications.JobOperations.Queries.GetJobs.GetJobsQuery;
using static WebApi.Applications.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserModel, User>();
            CreateMap<User, UserDetailViewModel>().ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Job.Name));
            CreateMap<User, UsersViewModel>().ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Job.Name));
            CreateMap<Job, JobsViewModel>();
            CreateMap<Job, JobDetailViewModel>();
        }
    }
}