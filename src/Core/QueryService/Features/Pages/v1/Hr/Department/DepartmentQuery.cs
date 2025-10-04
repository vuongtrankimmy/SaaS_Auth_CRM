using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Department;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Department
{
    public class DepartmentQuery(IQueryRepository repository) : BaseRepository<DepartmentModel>(repository, ApiEndpoint.Hr.Department), IDepartmentQuery
    {
    }
}
