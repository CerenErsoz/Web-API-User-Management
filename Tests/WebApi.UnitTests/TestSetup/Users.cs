using WebApi;
using WebApi.DBOperations;

namespace TestSetup
{
    public static class Users
    {
        public static void AddUser(this UserDBContext context)
        {
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
        }
    }
}