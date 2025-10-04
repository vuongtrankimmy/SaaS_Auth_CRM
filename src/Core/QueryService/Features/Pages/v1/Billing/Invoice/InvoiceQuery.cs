using Entities.Common.Endpoint;
using Entities.Features.Pages.Billing.Invoice;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Billing.Invoice
{
    public class InvoiceQuery(IQueryRepository repository) : BaseRepository<InvoiceModel>(repository, ApiEndpoint.Billing.Invoice), IInvoiceQuery
    {
    }
}
