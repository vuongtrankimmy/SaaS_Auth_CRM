using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Auth.Signin.Password
{
    public class PasswordQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IPasswordQuery
    {
        private static readonly string endpoint = ApiEndpoint.Auth.Signin.Password;
    }
}
