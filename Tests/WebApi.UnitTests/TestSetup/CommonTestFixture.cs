using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace TestSetup
{
    public class CommonTestFixture
    {
        public UserDBContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<UserDBContext>().UseInMemoryDatabase(databaseName: "UserTestDB").Options;
            Context = new UserDBContext(options);
            Context.Database.EnsureCreated();
            Context.AddUser();
            Context.AddJobs();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}