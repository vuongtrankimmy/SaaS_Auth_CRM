using Entities.Common.Endpoint;
using Entities.Features.Pages.Account.Application;
using QueryService.Features.Pages.v1.Account.Application;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.Account.Application
{
    public class ApplicationQuery(IQueryRepository repository) : BaseRepository<ApplicationModel>(repository, ApiEndpoint.Account.Application), IApplicationQuery
    {
    }
}
