using QueryService.Features.Pages.v1.Account;
using QueryService.Features.Pages.v1.Auth;
using QueryService.Features.Pages.v1.Billing;
using QueryService.Features.Pages.v1.Hr;
using Repositories.Repository;

namespace QueryService.Wrapper
{
    public class QueryWrapper(IQueryRepository queryRepository) : IQueryWrapper
    {
        public IAuthQuery AuthQuery => authQuery ??= new AuthQuery(queryRepository);
        IAuthQuery authQuery;

        public IAccountQuery AccountQuery => accountQuery ??= new AccountQuery(queryRepository);
        IAccountQuery accountQuery;

        public IBillingQuery BillingQuery => billingQuery ??= new BillingQuery(queryRepository);
        IBillingQuery billingQuery;

        public IHrQuery HrQuery => hrQuery ??= new HrQuery(queryRepository);
        IHrQuery hrQuery;
    }
}
