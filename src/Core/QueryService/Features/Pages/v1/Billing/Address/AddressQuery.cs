using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Billing.Address
{
    public class AddressQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IAddressQuery
    {
        private static readonly string endpoint = ApiEndpoint.Billing.Address;
    }
}
