using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Billing.Invoice
{
    public class InvoiceQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IInvoiceQuery
    {
        private static readonly string endpoint = ApiEndpoint.Billing.Invoice;
    }
}
