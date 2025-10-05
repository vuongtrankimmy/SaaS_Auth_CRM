using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Position
{
    public class PositionQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IPositionQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Position;
    }
}
