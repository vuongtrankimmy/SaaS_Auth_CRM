using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Billing.Service
{
    public class ServiceQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IServiceQuery
    {
        private static readonly string endpoint = ApiEndpoint.Billing.Service;
    }
}
