using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.JobOperations.Queries.GetJobs
{
    public class GetJobsQuery
    {
        public readonly IUserDbContext _context;
        public readonly IMapper _mapper;

        public GetJobsQuery(IUserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<JobsViewModel> Handle()
        {
            var jobs = _context.Jobs.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<JobsViewModel> returnObj = _mapper.Map<List<JobsViewModel>>(jobs);
            return returnObj;
        }

        public class JobsViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}