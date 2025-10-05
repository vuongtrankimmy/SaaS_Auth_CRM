using QueryService.Wrapper;
using Templates.Features.Pages.v1.Account;

namespace Templates.Wrapper
{
    public class TemplateWrapper(IQueryWrapper queryWrapper) : ITemplateWrapper
    {
        public IAccountService AccountService => accountService ??= new AccountService(queryWrapper);
        IAccountService? accountService;
    }
}
