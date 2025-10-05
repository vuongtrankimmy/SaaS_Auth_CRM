using QueryService.Wrapper;
using Shared.Data.Html;
using Shared.Helpers.Template.Html;

namespace Templates.Features.Pages.v1.Account.Setting
{
    public class SettingService(IQueryWrapper queryWrapper) : ISettingService
    {
        public async Task<string> GetAsync()
        {
            var htmlPath = HtmlPathFactory.Account.Setting;
            // var api = queryWrapper.AccountQuery.ApplicationQuery.GetAsync<AccountModel>(1);
            return await htmlPath.ToRender("");
        }
    }
}
