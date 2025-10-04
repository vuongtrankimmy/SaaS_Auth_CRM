using QueryService.Features.Pages.v1.Billing.Address;
using QueryService.Features.Pages.v1.Billing.Invoice;
using QueryService.Features.Pages.v1.Billing.Payment;
using QueryService.Features.Pages.v1.Billing.Service;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Billing
{
    public class BillingQuery(IQueryRepository? _queryRepository) : IBillingQuery
    {
        public IAddressQuery AddressQuery => addressQuery ??= new AddressQuery(_queryRepository);
        IAddressQuery? addressQuery;
        public IInvoiceQuery InvoiceQuery => invoiceQuery ??= new InvoiceQuery(_queryRepository);
        IInvoiceQuery? invoiceQuery;
        public IPaymentQuery PaymentQuery => paymentQuery ??= new PaymentQuery(_queryRepository);
        IPaymentQuery? paymentQuery;
        public IServiceQuery ServiceQuery => serviceQuery ??= new ServiceQuery(_queryRepository);
        IServiceQuery? serviceQuery;
    }
}
