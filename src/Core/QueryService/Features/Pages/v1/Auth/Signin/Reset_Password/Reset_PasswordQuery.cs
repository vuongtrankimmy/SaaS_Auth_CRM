using Entities.Common.Endpoint;
using Entities.Features.Pages.Auth.Sigin.Reset_Password;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signin.Reset_Password
{
    public class Reset_PasswordQuery(IQueryRepository repository) : BaseRepository<Reset_PasswordModel>(repository, ApiEndpoint.Auth.Signin.ResetPassword), IReset_PasswordQuery
    {
    }
}
