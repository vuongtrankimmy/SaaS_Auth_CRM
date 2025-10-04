using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.KPI;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.KPI
{
    public class KPIQuery(IQueryRepository repository) : BaseRepository<KPIModel>(repository, ApiEndpoint.Hr.Kpi), IKPIQuery
    {
    }
}
