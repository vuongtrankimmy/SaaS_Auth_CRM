using QueryService.Features.Pages.v1.Account;
using QueryService.Features.Pages.v1.Auth;
using QueryService.Features.Pages.v1.Billing;
using Repositories.Repository;

namespace QueryService.Wrapper
{
    public class QueryWrapper(IQueryRepository? _queryRepository) : IQueryWrapper
    {
        public IAuthQuery AuthQuery => authQuery ??= new AuthQuery(_queryRepository);
        IAuthQuery? authQuery;

        public IAccountQuery AccountQuery => accountQuery ??= new AccountQuery(_queryRepository);
        IAccountQuery? accountQuery;

        public IBillingQuery BillingQuery => billingQuery ??= new BillingQuery(_queryRepository);
        IBillingQuery? billingQuery;
    }
}
