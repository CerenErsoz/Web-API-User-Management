using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{

    public class UserDBContext : DbContext, IUserDbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}