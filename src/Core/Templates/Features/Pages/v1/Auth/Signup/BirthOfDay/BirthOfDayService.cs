using QueryService.Wrapper;
using Shared.Data.Html;
using Shared.Helpers.Template.Html;

namespace Templates.Features.Pages.v1.Auth.Signup.BirthOfDay
{
    public class BirthOfDayService(IQueryWrapper queryWrapper) : IBirthOfDayService
    {
        public async Task<string> GetAsync()
        {
            var htmlPath = HtmlPathFactory.Auth.Signup.BirthOfDay;
            // var api = queryWrapper.AccountQuery.ApplicationQuery.GetAsync<AccountModel>(1);
            return await htmlPath.ToRender("");
        }
    }
}
