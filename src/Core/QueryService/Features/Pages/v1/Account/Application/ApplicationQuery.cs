using Entities.Common.Endpoint;
using QueryService.Features.Pages.v1.Account.Application;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.Account.Application
{
    public class ApplicationQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IApplicationQuery
    {
        private static readonly string endpoint = ApiEndpoint.Account.Application;
    }
}
