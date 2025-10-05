using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Component
{
    public class ComponentQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IComponentQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Component;
    }
}
