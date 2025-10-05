using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Billing.Payment
{
    public class PaymentQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IPaymentQuery
    {
        private static readonly string endpoint = ApiEndpoint.Billing.Payment;
    }
}
