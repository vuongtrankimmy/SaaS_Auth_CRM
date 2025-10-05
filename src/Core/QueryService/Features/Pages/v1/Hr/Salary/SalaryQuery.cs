using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Salary
{
    public class SalaryQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), ISalaryQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Salary;
    }
}
