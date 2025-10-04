using Entities.Common.Endpoint;
using Entities.Features.Pages.Auth.Signup.Basic_Information;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signup.Basic_Information
{
    public class Basic_InformationQuery(IQueryRepository repository) : BaseRepository<Basic_InformationModel>(repository, ApiEndpoint.Auth.Signup.BasicInformation), IBasic_InformationQuery
    {
    }
}
