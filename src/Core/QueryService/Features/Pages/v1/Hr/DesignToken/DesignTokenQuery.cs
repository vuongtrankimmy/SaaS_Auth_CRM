using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.DesignToken
{
    public class DesignTokenQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IDesignTokenQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.DesignToken;
    }
}
