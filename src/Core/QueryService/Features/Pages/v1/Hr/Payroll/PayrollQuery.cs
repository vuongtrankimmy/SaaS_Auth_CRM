using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Payroll
{
    public class PayrollQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IPayrollQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Payroll;
    }
}
