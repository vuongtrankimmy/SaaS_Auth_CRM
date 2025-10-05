using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Account.Workspace
{
    public class WorkspaceQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IWorkspaceQuery
    {
        private static readonly string endpoint = ApiEndpoint.Account.Workspace;
    }
}
