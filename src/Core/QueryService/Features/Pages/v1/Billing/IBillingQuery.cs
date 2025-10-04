using QueryService.Features.Pages.v1.Billing.Address;
using QueryService.Features.Pages.v1.Billing.Invoice;
using QueryService.Features.Pages.v1.Billing.Payment;
using QueryService.Features.Pages.v1.Billing.Service;

namespace QueryService.Features.Pages.v1.Billing
{
    public interface IBillingQuery
    {
        IAddressQuery AddressQuery {  get; }
        IInvoiceQuery InvoiceQuery {  get; }
        IPaymentQuery PaymentQuery {  get; }
        IServiceQuery ServiceQuery {  get; }
    }
}
