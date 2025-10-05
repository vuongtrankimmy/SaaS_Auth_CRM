using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Insurance
{
    public class InsuranceQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IInsuranceQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Insurance;
    }
}
