using Entities.Common.Endpoint;
using Entities.Features.Pages.Billing.Payment;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Billing.Payment
{
    public class PaymentQuery(IQueryRepository repository) : BaseRepository<PaymentModel>(repository, ApiEndpoint.Billing.Payment), IPaymentQuery
    {
    }
}
