using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Tax
{
    public class TaxQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), ITaxQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Tax;
    }
}
