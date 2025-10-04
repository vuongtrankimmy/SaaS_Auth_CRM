using QueryService.Features.Pages.Account.Application;
using QueryService.Features.Pages.v1.Account.Application;
using QueryService.Features.Pages.v1.Account.Security;
using QueryService.Features.Pages.v1.Account.Setting;
using QueryService.Features.Pages.v1.Account.Workspace;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Account
{
    public class AccountQuery(IQueryRepository? _queryRepository) : IAccountQuery
    {
        public IApplicationQuery ApplicationQuery => applicationQuery ??= new ApplicationQuery(_queryRepository);
        IApplicationQuery? applicationQuery;
        public ISecurityQuery SecurityQuery => securityQuery ??= new SecurityQuery(_queryRepository);
        ISecurityQuery? securityQuery;
        public ISettingQuery SettingQuery => settingQuery ??= new SettingQuery(_queryRepository);
        ISettingQuery? settingQuery;
        public IWorkspaceQuery WorkspaceQuery => workspaceQuery ??= new WorkspaceQuery(_queryRepository);
        IWorkspaceQuery? workspaceQuery;
    }
}
