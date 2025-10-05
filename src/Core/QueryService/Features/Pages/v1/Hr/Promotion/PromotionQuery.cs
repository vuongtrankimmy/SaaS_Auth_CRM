using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Promotion
{
    public class PromotionQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IPromotionQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Promotion;
    }
}
