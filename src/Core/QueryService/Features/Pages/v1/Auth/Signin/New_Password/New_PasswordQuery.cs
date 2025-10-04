using Entities.Common.Endpoint;
using Entities.Features.Pages.Auth.Sigin.New_Password;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signin.New_Password
{
    public class New_PasswordQuery(IQueryRepository repository) : BaseRepository<New_PasswordModel>(repository, ApiEndpoint.Auth.NewPassword), INew_PasswordQuery
    {
    }
}
