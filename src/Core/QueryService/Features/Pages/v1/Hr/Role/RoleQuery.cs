using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Role;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Role
{
    public class RoleQuery(IQueryRepository repository) : BaseRepository<RoleModel>(repository, ApiEndpoint.Hr.Role), IRoleQuery
    {
    }
}
