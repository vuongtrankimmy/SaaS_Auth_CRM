using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Account;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signup.Email
{
    public class EmailQuery(IQueryRepository repository) : BaseRepository<AccountModel>(repository, ApiEndpoint.Auth.Signup.Email), IEmailQuery
    {
    }
}
