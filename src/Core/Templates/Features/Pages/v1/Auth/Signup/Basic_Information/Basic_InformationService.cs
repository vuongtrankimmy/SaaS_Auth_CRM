using QueryService.Wrapper;
using Shared.Data.Html;
using Shared.Helpers.Template.Html;

namespace Templates.Features.Pages.v1.Auth.Signup.Basic_Information
{
    public class Basic_InformationService(IQueryWrapper queryWrapper) : IBasic_InformationService
    {
        public async Task<string> GetAsync()
        {
            var htmlPath = HtmlPathFactory.Auth.Signup.Basic_Information;
            // var api = queryWrapper.AccountQuery.ApplicationQuery.GetAsync<AccountModel>(1);
            return await htmlPath.ToRender("");
        }
    }
}
