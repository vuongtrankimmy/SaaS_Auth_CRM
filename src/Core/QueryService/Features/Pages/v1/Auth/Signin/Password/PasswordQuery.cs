using Entities.Common.Endpoint;
using Entities.Features.Pages.Auth.Sigin.Password;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signin.Password
{
    public class PasswordQuery(IQueryRepository repository) : BaseRepository<PasswordModel>(repository, ApiEndpoint.Auth.Signin.Password), IPasswordQuery
    {
    }
}
