using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Employee;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Employee
{
    public class EmployeeQuery(IQueryRepository repository) : BaseRepository<EmployeeModel>(repository, ApiEndpoint.Hr.Employee), IEmployeeQuery
    {
    }
}
