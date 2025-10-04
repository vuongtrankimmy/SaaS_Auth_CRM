using QueryService.Features.Pages.v1.Account;
using QueryService.Features.Pages.v1.Auth;
using QueryService.Features.Pages.v1.Billing;

namespace QueryService.Wrapper
{
    public interface IQueryWrapper
    {
        IAuthQuery AuthQuery { get; }
        IAccountQuery AccountQuery {  get; }
        IBillingQuery BillingQuery {  get; }
    }
}
