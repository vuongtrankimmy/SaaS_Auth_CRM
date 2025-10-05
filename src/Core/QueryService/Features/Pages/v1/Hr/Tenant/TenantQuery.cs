using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Tenant
{
    public class TenantQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), ITenantQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Tenant;
    }
}
