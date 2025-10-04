using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Account;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signin.Account
{
    public class AccountQuery(IQueryRepository repository) : BaseRepository<AccountModel>(repository, ApiEndpoint.Auth.Signin.Account), IAccountQuery
    {
    }
}
