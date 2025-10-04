using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Account;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Account
{
    public class AccountQuery(IQueryRepository repository) : BaseRepository<AccountModel>(repository, ApiEndpoint.Hr.Account), IAccountQuery
    {
    }
}
