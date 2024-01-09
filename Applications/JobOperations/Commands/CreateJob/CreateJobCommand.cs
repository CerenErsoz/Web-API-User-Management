using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.JobOperations.Commands.CreateJob
{
    public class CreateJobCommand
    {
        public CreateJobModel Model { get; set; }
        private readonly IUserDbContext _context;

        public CreateJobCommand(IUserDbContext context)
        {
            _context = context;
        }


        public void Handle()
        {
            var job = _context.Jobs.SingleOrDefault(x => x.Name == Model.Name);
            if (job is not null)
                throw new InvalidOperationException("Job is already exist.");

            job = new Job();
            job.Name = Model.Name;
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }
    }

    public class CreateJobModel
    {
        public string Name { get; set; }
    }
}