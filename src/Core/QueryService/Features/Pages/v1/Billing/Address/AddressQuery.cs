using Entities.Common.Endpoint;
using Entities.Features.Pages.Billing.Address;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Billing.Address
{
    public class AddressQuery(IQueryRepository repository) : BaseRepository<AddressModel>(repository, ApiEndpoint.Billing.Address), IAddressQuery
    {
    }
}
