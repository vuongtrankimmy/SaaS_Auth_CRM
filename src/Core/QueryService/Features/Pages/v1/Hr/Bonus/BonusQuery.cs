using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Bonus
{
    public class BonusQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IBonusQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Bonus;
    }
}
