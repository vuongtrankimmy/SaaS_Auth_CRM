using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Leave;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Leave
{
    public class LeaveQuery(IQueryRepository repository) : BaseRepository<LeaveModel>(repository, ApiEndpoint.Hr.Leave), ILeaveQuery
    {
    }
}
