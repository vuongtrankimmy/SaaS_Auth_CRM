using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Account.Security
{
    public class SecurityQuery(IQueryRepository queryRepository):Repository(queryRepository, endpoint), ISecurityQuery
    {
        private static readonly string endpoint = ApiEndpoint.Account.Security;
    }
}
