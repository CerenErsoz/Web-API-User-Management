using WebApi.DBOperations;

namespace WebApi.Applications.JobOperations.Commands.DeleteJob
{
    public class DeleteJobCommand
    {
        public int JobId { get; set; }
        private readonly IUserDbContext _context;
        public DeleteJobCommand(IUserDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var job = _context.Jobs.SingleOrDefault(x => x.Id == JobId);
            if (job is null)
                throw new InvalidOperationException("Job is not found.");

            _context.Jobs.Remove(job);
            _context.SaveChanges();
        }
    }
}