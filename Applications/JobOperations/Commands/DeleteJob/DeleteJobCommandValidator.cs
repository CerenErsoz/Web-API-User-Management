using FluentValidation;

namespace WebApi.Applications.JobOperations.Commands.DeleteJob
{
    public class DeleteJobCommandValidator : AbstractValidator<DeleteJobCommand>
    {
        public DeleteJobCommandValidator()
        {
            RuleFor(command => command.JobId).GreaterThan(0);
        }
    }
}