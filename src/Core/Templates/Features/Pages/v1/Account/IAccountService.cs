using Templates.Features.Pages.v1.Account.Application;
using Templates.Features.Pages.v1.Account.Security;
using Templates.Features.Pages.v1.Account.Setting;
using Templates.Features.Pages.v1.Account.Workspace;

namespace Templates.Features.Pages.v1.Account
{
    public interface IAccountService
    {
        IApplicationService ApplicationService { get; }
        ISecurityService SecurityService {  get; }
        ISettingService SettingService {  get; }
        IWorkspaceService WorkspaceService {  get; }
    }
}
