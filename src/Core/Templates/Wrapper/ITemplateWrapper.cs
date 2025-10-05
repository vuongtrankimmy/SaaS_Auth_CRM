using Templates.Features.Pages.v1.Account;
using Templates.Features.Pages.v1.Auth;

namespace Templates.Wrapper
{
    public interface ITemplateWrapper
    {
        IAccountService AccountService {  get; }
        IAuthService AuthService { get; }
    }
}
