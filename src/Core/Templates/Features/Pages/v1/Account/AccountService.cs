using QueryService.Wrapper;
using Templates.Features.Pages.v1.Account.Application;
using Templates.Features.Pages.v1.Account.Security;
using Templates.Features.Pages.v1.Account.Setting;
using Templates.Features.Pages.v1.Account.Workspace;

namespace Templates.Features.Pages.v1.Account
{
    public class AccountService(IQueryWrapper queryWrapper) : IAccountService
    {
        public IApplicationService ApplicationService => applicationService ??= new ApplicationService(queryWrapper);
        IApplicationService? applicationService;

        public ISecurityService SecurityService => securityService ??= new SecurityService(queryWrapper);
        ISecurityService? securityService;

        public ISettingService SettingService => settingService ??= new SettingService(queryWrapper);
        ISettingService? settingService;

        public IWorkspaceService WorkspaceService => workspaceService ??= new WorkspaceService(queryWrapper);
        IWorkspaceService? workspaceService;
    }
}
