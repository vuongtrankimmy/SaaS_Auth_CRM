using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Account
{
    public class AccountQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IAccountQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Account;
    }
}
