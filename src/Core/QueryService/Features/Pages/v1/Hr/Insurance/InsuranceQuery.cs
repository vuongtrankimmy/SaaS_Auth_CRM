using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Insurance;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Insurance
{
    public class InsuranceQuery(IQueryRepository repository) : BaseRepository<InsuranceModel>(repository, ApiEndpoint.Hr.Insurance), IInsuranceQuery
    {
    }
}
