using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Auth.Signup.Verify
{
    public class VerifyQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IVerifyQuery
    {
        private static readonly string endpoint = ApiEndpoint.Auth.Signup.Verify;
    }
}
