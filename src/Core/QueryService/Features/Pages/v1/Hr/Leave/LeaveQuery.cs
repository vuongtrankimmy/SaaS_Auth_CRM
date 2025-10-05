using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Leave
{
    public class LeaveQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), ILeaveQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Leave;
    }
}
