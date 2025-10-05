using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Employee
{
    public class EmployeeQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IEmployeeQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Employee;
    }
}
