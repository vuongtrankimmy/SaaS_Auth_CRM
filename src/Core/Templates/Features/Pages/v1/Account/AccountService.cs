using QueryService.Wrapper;
using Templates.Features.Pages.v1.Account.Application;

namespace Templates.Features.Pages.v1.Account
{
    public class AccountService(IQueryWrapper queryWrapper): IAccountService
    {
        public IApplicationService ApplicationService => applicationService ??= new ApplicationService(queryWrapper);
        IApplicationService? applicationService;
    }
}
