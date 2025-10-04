using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Component;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Component
{
    public class ComponentQuery(IQueryRepository repository) : BaseRepository<ComponentModel>(repository, ApiEndpoint.Hr.Component), IComponentQuery
    {
    }
}
