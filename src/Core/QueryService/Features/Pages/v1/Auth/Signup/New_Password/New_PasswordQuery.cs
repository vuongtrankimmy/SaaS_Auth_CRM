using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Account;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signup.New_Password
{
    public class New_PasswordQuery(IQueryRepository repository) : BaseRepository<AccountModel>(repository, ApiEndpoint.Auth.NewPassword), INew_PasswordQuery
    {
    }
}
