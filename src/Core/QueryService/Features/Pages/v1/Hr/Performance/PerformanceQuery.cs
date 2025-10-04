using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Performance;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Performance
{
    public class PerformanceQuery(IQueryRepository repository) : BaseRepository<PerformanceModel>(repository, ApiEndpoint.Hr.Performance), IPerformanceQuery
    {
    }
}
