using Entities.Common.Endpoint;
using Entities.Features.Pages.Auth.Signup.BirthOfDay;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signup.BirthOfDay
{
    public class BirthOfDayQuery(IQueryRepository repository) : BaseRepository<BirthOfDayModel>(repository, ApiEndpoint.Auth.Signup.BasicInformation), IBirthOfDayQuery
    {
    }
}
