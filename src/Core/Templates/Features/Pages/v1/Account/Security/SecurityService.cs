using QueryService.Wrapper;
using Shared.Data.Html;
using Shared.Helpers.Template.Html;

namespace Templates.Features.Pages.v1.Account.Security
{
    public class SecurityService(IQueryWrapper queryWrapper) : ISecurityService
    {
        public async Task<string> GetAsync()
        {
            var htmlPath = HtmlPathFactory.Account.Security;
           // var api = queryWrapper.AccountQuery.ApplicationQuery.GetAsync<AccountModel>(1);
            return await htmlPath.ToRender("");
        }
    }
}
