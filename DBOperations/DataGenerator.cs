using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

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

                context.Users.AddRange(
                    new User
                    {
                        Name = "Ceren Ersoz",
                        Email = "ersozceren2@gmail.com",
                        Phone = "123456",
                        JobId = 1
                    },
                    new User
                    {
                        Name = "Fatih Varol",
                        Email = "f@gmail.com",
                        Phone = "123456",
                        JobId = 1
                    },
                    new User
                    {
                        Name = "Eleanor Johnson",
                        Email = "eleanor.johnson@example.com",
                        Phone = "+1234567890",
                        JobId = 2
                    },
                    new User
                    {
                        Name = "Liam Smith",
                        Email = "liam.smith@example.com",
                        Phone = "+9876543210",
                        JobId = 3
                    },
                    new User
                    {
                        Name = "Ceren Ceren",
                        Email = "ersozceren2@gmail.com",
                        Phone = "123456",
                        JobId = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }

}