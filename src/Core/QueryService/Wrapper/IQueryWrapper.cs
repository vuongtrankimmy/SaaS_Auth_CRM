using QueryService.Features.Pages.v1.Account;
using QueryService.Features.Pages.v1.Auth;
using QueryService.Features.Pages.v1.Billing;
using QueryService.Features.Pages.v1.Hr;

namespace QueryService.Wrapper
{
    public interface IQueryWrapper
    {
        IAuthQuery AuthQuery { get; }
        IAccountQuery AccountQuery {  get; }
        IBillingQuery BillingQuery {  get; }
        IHrQuery HrQuery {  get; }
    }
}
