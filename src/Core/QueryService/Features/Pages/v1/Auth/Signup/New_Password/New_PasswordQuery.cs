using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Auth.Signup.New_Password
{
    public class New_PasswordQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), INew_PasswordQuery
    {
        private static readonly string endpoint = ApiEndpoint.Auth.NewPassword;
    }
}
