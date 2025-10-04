using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Account;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signin.Verify_Type
{
    public class Verify_TypeQuery(IQueryRepository repository) : BaseRepository<AccountModel>(repository, ApiEndpoint.Auth.Signin.VerifyType), IVerify_TypeQuery
    {
    }
}
