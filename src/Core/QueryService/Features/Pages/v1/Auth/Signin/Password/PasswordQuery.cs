using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Account;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signin.Password
{
    public class PasswordQuery(IQueryRepository repository) : BaseRepository<AccountModel>(repository, ApiEndpoint.Auth.Signin.Password), IPasswordQuery
    {
    }
}
