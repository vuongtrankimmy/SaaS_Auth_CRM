using Entities.Common.Endpoint;
using Entities.Features.Pages.Auth.Signup.Your_Name;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signup.Your_Name
{
    public class Your_NameQuery(IQueryRepository repository) : BaseRepository<Your_NameModel>(repository, ApiEndpoint.Auth.Signup.YourName), IYour_NameQuery
    {
    }
}
