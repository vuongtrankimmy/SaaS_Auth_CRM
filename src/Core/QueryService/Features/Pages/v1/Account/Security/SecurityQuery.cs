using Entities.Common.Endpoint;
using Entities.Features.Pages.Account.Security;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Account.Security
{
    public class SecurityQuery(IQueryRepository repository) : BaseRepository<SecurityModel>(repository, ApiEndpoint.Account.Security), ISecurityQuery
    {
    }
}
