using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Auth.Signin.Reset_Password
{
    public class Reset_PasswordQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IReset_PasswordQuery
    {
        private static readonly string endpoint = ApiEndpoint.Auth.Signin.ResetPassword;
    }
}
