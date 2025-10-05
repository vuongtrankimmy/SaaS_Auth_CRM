using Microsoft.AspNetCore.Components;
using Templates.Wrapper;

namespace Host.Auth.Components.Pages.Account.Application
{
    public partial class Application
    {
        [Inject]
        ITemplateWrapper _template { get; set; }
        public string renderHtml { get; set; } = "";
        protected override async Task OnInitializedAsync()
        {
            renderHtml = await _template.AccountService.ApplicationService.GetAsync();
        }
    }
}
