using QueryService.Wrapper;
using Shared.Data.Html;
using Shared.Helpers.Template.Html;

namespace Templates.Features.Pages.v1.Account.Workspace
{
    public class WorkspaceService(IQueryWrapper queryWrapper) : IWorkspaceService
    {
        public async Task<string> GetAsync()
        {
            var htmlPath = HtmlPathFactory.Account.Workspace;
            // var api = queryWrapper.AccountQuery.ApplicationQuery.GetAsync<AccountModel>(1);
            return await htmlPath.ToRender("");
        }
    }
}
