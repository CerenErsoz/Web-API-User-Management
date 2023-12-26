using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations
{

    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UserDBContext(serviceProvider.GetRequiredService<DbContextOptions<UserDBContext>>()))
            {
                if (context.Users.Any())
                    return;
                context.Users.AddRange(
                    new User
                    {
                        Name = "Ceren Ersoz",
                        Email = "ersozceren2@gmail.com",
                        Phone = "123456",
                        JobId = 1//"Computer Engineer"
                    },
                    new User
                    {
                        Name = "Fatih Varol",
                        Email = "f@gmail.com",
                        Phone = "123456",
                        JobId = 1//"Computer Engineer"
                    },
                    new User
                    {
                        Name = "Eleanor Johnson",
                        Email = "eleanor.johnson@example.com",
                        Phone = "+1234567890",
                        JobId = 2//"Security Analyst"
                    },
                    new User
                    {
                        Name = "Liam Smith",
                        Email = "liam.smith@example.com",
                        Phone = "+9876543210",
                        JobId = 3//"Data Analyst"
                    },
                    new User
                    {
                        Name = "Ceren Ceren",
                        Email = "ersozceren2@gmail.com",
                        Phone = "123456",
                        JobId = 1//"Computer Engineer"
                    }
                );
                context.SaveChanges();
            }
        }
    }

}