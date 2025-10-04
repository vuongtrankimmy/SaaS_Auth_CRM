using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Tax;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Tax
{
    public class TaxQuery(IQueryRepository repository) : BaseRepository<TaxModel>(repository, ApiEndpoint.Hr.Tax), ITaxQuery
    {
    }
}
