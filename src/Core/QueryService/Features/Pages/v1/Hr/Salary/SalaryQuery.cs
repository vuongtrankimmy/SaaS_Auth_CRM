using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Salary;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Salary
{
    public class SalaryQuery(IQueryRepository repository) : BaseRepository<SalaryModel>(repository, ApiEndpoint.Hr.Salary), ISalaryQuery
    {
    }
}
