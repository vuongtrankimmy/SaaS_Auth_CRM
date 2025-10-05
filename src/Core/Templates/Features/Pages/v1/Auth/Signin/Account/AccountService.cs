using QueryService.Wrapper;
using Shared.Data.Html;
using Shared.Helpers.Template.Html;

namespace Templates.Features.Pages.v1.Auth.Signin.Account
{
    public class AccountService(IQueryWrapper queryWrapper) : IAccountService
    {
        public async Task<string> GetAsync()
        {
            var htmlPath = HtmlPathFactory.Auth.Signin.Account;
            // var api = queryWrapper.AccountQuery.ApplicationQuery.GetAsync<AccountModel>(1);
            return await htmlPath.ToRender("");
        }
    }
}
