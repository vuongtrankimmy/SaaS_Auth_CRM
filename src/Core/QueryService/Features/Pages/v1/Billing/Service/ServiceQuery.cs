using Entities.Common.Endpoint;
using Entities.Features.Pages.Billing.Service;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Billing.Service
{
    public class ServiceQuery(IQueryRepository repository) : BaseRepository<ServiceModel>(repository, ApiEndpoint.Billing.Service), IServiceQuery
    {
    }
}
