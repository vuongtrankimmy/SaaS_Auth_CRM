using Entities.Common.Endpoint;
using Entities.Features.Pages.Account.Workspace;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Account.Workspace
{
    public class WorkspaceQuery(IQueryRepository repository) : BaseRepository<WorkspaceModel>(repository, ApiEndpoint.Account.Workspace), IWorkspaceQuery
    {
    }
}
