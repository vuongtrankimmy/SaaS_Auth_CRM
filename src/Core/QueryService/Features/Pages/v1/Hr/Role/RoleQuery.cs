using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Role
{
    public class RoleQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IRoleQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Role;
    }
}
