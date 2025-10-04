using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Bonus;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Bonus
{
    public class BonusQuery(IQueryRepository repository) : BaseRepository<BonusModel>(repository, ApiEndpoint.Hr.Bonus), IBonusQuery
    {
    }
}
