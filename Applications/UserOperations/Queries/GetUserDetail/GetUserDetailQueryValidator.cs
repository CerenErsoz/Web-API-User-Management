using FluentValidation;

namespace WebApi.Applications.UserOperations.Queries.GetUserDetailQuery
{
    public class GetUserDetailQueryValidator : AbstractValidator<GetUserDetailQuery>
    {
        public GetUserDetailQueryValidator()
        {
            RuleFor(query => query.UserId).GreaterThan(0);
        }
    }
}