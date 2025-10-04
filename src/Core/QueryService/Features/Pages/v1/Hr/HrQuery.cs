using QueryService.Features.Pages.v1.Account;
using QueryService.Features.Pages.v1.Billing.Invoice;
using QueryService.Features.Pages.v1.Billing.Payment;
using QueryService.Features.Pages.v1.Billing.Service;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr
{
    public class HrQuery(IQueryRepository? _queryRepository) : IHrQuery
    {
        public IAccountQuery AccountQuery => accountQuery ??= new AccountQuery(_queryRepository);
        IAccountQuery? accountQuery;
        public IInvoiceQuery InvoiceQuery => invoiceQuery ??= new InvoiceQuery(_queryRepository);
        IInvoiceQuery? invoiceQuery;
        public IPaymentQuery PaymentQuery => paymentQuery ??= new PaymentQuery(_queryRepository);
        IPaymentQuery? paymentQuery;
        public IServiceQuery ServiceQuery => serviceQuery ??= new ServiceQuery(_queryRepository);
        IServiceQuery? serviceQuery;
    }
}
