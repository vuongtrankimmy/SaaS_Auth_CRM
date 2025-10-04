using Entities.Common.Endpoint;
using Entities.Features.Pages.Auth.Signup.Verify;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signup.Verify
{
    public class VerifyQuery(IQueryRepository repository) : BaseRepository<VerifyModel>(repository, ApiEndpoint.Auth.Signup.Verify), IVerifyQuery
    {
    }
}
