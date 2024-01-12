using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi;
using WebApi.Applications.UserOperations.Commands.CreateUser;
using WebApi.DBOperations;
using static WebApi.Applications.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace Applications.UserOperations.Commands.CreateUser
{
    public class CreateUserCommandTest : IClassFixture<CommonTestFixture>
    {
        public UserDBContext _context { get; set; }
        public IMapper _mapper { get; set; }


        public CreateUserCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }


        [Fact]
        public void WhenAlreadyExistUsersEmailIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange-hazırlık
            var user = new User() { Name = "Test", Email = "Test", Phone = "Test", JobId = 1 };
            _context.Users.Add(user);
            _context.SaveChanges();

            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = new CreateUserModel() { Name = user.Name };

            //act-calıştırma, assert-doğrulama
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("User is already exist");
        }
    }
}