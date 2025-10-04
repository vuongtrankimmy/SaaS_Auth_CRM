using QueryService.Features.Pages.v1.Account.Application;
using QueryService.Features.Pages.v1.Account.Security;
using QueryService.Features.Pages.v1.Account.Setting;
using QueryService.Features.Pages.v1.Account.Workspace;

namespace QueryService.Features.Pages.v1.Account
{
    public interface IAccountQuery
    {
        IApplicationQuery ApplicationQuery {  get; }
        ISecurityQuery SecurityQuery {  get; }
        ISettingQuery SettingQuery {  get; }
        IWorkspaceQuery WorkspaceQuery {  get; }
    }
}
