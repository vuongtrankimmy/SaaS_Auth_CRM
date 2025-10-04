using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Attendance;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Attendance
{
    public class AttendanceQuery(IQueryRepository repository) : BaseRepository<AttendanceModel>(repository, ApiEndpoint.Hr.Attendance), IAttendanceQuery
    {
    }
}
