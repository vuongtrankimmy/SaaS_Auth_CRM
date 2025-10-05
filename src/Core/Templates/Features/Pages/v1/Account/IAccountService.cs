using Templates.Features.Pages.v1.Account.Application;

namespace Templates.Features.Pages.v1.Account
{
    public interface IAccountService
    {
        IApplicationService ApplicationService {  get; }
    }
}
