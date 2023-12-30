using FluentValidation;

namespace WebApi.Applications.JobOperations.Queries.GetJobDetail
{

    public class GetJobDetailValidator : AbstractValidator<GetJobDetailQuery>
    {
        public GetJobDetailValidator()
        {
            RuleFor(query => query.JobId).GreaterThan(0);
        }
    }
}