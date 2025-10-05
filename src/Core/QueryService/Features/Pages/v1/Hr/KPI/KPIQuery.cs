using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.KPI
{
    public class KPIQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IKPIQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Kpi;
    }
}
