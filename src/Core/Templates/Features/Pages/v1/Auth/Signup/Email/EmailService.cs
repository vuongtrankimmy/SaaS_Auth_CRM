using QueryService.Wrapper;
using Shared.Data.Html;
using Shared.Helpers.Template.Html;

namespace Templates.Features.Pages.v1.Auth.Signup.Email
{
    public class EmailService(IQueryWrapper queryWrapper) : IEmailService
    {
        public async Task<string> GetAsync()
        {
            var htmlPath = HtmlPathFactory.Auth.Signup.Email;
            // var api = queryWrapper.AccountQuery.ApplicationQuery.GetAsync<AccountModel>(1);
            return await htmlPath.ToRender("");
        }
    }
}
