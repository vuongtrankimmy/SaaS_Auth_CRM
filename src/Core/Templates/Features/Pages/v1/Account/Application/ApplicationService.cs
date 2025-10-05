using Entities.Features.Pages.Hr.Account;
using QueryService.Wrapper;
using Shared.Data.Html;
using Shared.Helpers.Template.Html;

namespace Templates.Features.Pages.v1.Account.Application
{
    public class ApplicationService(IQueryWrapper queryWrapper) : IApplicationService
    {
        public async Task<string> GetAsync()
        {
            var htmlPath = HtmlPathFactory.Account.Application;
            //var api =await queryWrapper.AccountQuery.ApplicationQuery.GetAsync<AccountModel>();
            return await htmlPath.ToRender("");
        }
    }
}
