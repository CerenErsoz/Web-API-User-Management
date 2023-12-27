using FluentValidation;

namespace WebApi.UserOperations.GetUserDetailQuery
{
    public class GetUserDetailQueryValidator : AbstractValidator<GetUserDetailQuery>
    {
        public GetUserDetailQueryValidator()
        {
            RuleFor(query => query.UserId).GreaterThan(0);
        }
    }
}