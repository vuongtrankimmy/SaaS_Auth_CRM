using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Attendance
{
    public class AttendanceQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IAttendanceQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Attendance;
    }
}
