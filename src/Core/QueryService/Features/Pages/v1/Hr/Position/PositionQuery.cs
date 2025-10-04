using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Position;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Position
{
    public class PositionQuery(IQueryRepository repository) : BaseRepository<PositionModel>(repository, ApiEndpoint.Hr.Position), IPositionQuery
    {
    }
}
