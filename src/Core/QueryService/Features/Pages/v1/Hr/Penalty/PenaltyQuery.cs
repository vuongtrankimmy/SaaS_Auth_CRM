using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Penalty
{
    public class PenaltyQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IPenaltyQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Penalty;
    }
}
