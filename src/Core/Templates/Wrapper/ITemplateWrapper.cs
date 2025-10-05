using Templates.Features.Pages.v1.Account;

namespace Templates.Wrapper
{
    public interface ITemplateWrapper
    {
        IAccountService AccountService {  get; }
    }
}
