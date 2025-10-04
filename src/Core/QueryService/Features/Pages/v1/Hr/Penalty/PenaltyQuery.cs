using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Penalty;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Penalty
{
    public class PenaltyQuery(IQueryRepository repository) : BaseRepository<PenaltyModel>(repository, ApiEndpoint.Hr.Penalty), IPenaltyQuery
    {
    }
}
