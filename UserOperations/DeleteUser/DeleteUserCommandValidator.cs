using FluentValidation;

namespace WebApi.UserOperations.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(command => command.UserId).GreaterThan(0);
        }
    }
}