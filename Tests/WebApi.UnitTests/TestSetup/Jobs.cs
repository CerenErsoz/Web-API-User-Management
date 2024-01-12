using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Jobs
    {
        public static void AddJobs(this UserDBContext context)
        {
            context.Jobs.AddRange(
                    new Job
                    {
                        Name = "Computer Engineer",
                    },
                    new Job
                    {
                        Name = "Security Analyst",
                    },
                    new Job
                    {
                        Name = "Data Analyst",
                    },
                    new Job
                    {
                        Name = "Doctor",
                    }
                );
        }
    }
}