using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Promotion;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Promotion
{
    public class PromotionQuery(IQueryRepository repository) : BaseRepository<PromotionModel>(repository, ApiEndpoint.Hr.Promotion), IPromotionQuery
    {
    }
}
