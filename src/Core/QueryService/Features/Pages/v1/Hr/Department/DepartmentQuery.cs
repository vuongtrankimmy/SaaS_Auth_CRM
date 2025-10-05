using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Department
{
    public class DepartmentQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IDepartmentQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Department;
    }
}
