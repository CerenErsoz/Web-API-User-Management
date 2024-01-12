using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi;
using WebApi.Applications.UserOperations.Commands.CreateUser;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.Applications.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace Applications.UserOperations.Commands.CreateUser
{
    public class CreateUserComandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", "", "", 0)]
        [InlineData("ceren", "", "test", 1)]
        [InlineData("ceren", "test", "", 1)]
        [InlineData("ceren", "test", "test", 0)]
        [InlineData("", "", "test", 1)]
        [InlineData(" ", " ", " ", 1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string email, string phone, int jobId)
        {
            //arrange
            CreateUserCommand command = new CreateUserCommand(null, null);
            command.Model = new CreateUserModel()
            {
                Name = name,
                Email = email,
                Job = jobId,
                Phone = phone
            };

            //act
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeNotReturnError()
        {
            //arrange
            CreateUserCommand command = new CreateUserCommand(null, null);
            command.Model = new CreateUserModel()
            {
                Name = "name",
                Email = "email",
                Job = 1,
                Phone = "phone"
            };

            //act
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}