using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.DesignToken;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.DesignToken
{
    public class DesignTokenQuery(IQueryRepository repository) : BaseRepository<DesignTokenModel>(repository, ApiEndpoint.Hr.DesignToken), IDesignTokenQuery
    {
    }
}
