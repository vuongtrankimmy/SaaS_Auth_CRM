using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Auth.Signin.Verify_Type
{
    public class Verify_TypeQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IVerify_TypeQuery
    {
        private static readonly string endpoint = ApiEndpoint.Auth.Signin.VerifyType;
    }
}
