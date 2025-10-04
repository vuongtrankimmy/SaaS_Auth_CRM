using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Payroll;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Payroll
{
    public class PayrollQuery(IQueryRepository repository) : BaseRepository<PayrollModel>(repository, ApiEndpoint.Hr.Payroll), IPayrollQuery
    {
    }
}
