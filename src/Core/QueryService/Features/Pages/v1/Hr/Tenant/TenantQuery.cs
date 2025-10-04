using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Tenant;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Tenant
{
    public class TenantQuery(IQueryRepository repository) : BaseRepository<TenantModel>(repository, ApiEndpoint.Hr.Tenant), ITenantQuery
    {
    }
}
