using QueryService.Wrapper;
using Shared.Data.Html;
using Shared.Helpers.Template.Html;

namespace Templates.Features.Pages.v1.Auth.Account_Choose
{
    public class Account_ChooseService(IQueryWrapper queryWrapper) : IAccount_ChooseService
    {
        public async Task<string> GetAsync()
        {
            var htmlPath = HtmlPathFactory.Auth.AccountChoose;
            // var api = queryWrapper.AccountQuery.ApplicationQuery.GetAsync<AccountModel>(1);
            return await htmlPath.ToRender("");
        }
    }
}
