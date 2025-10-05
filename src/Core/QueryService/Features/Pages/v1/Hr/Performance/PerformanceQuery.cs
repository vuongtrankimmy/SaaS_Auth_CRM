using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Performance
{
    public class PerformanceQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IPerformanceQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Performance;
    }
}
