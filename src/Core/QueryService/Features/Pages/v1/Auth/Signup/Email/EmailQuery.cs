using Entities.Common.Endpoint;
using Entities.Features.Pages.Auth.Signup.Email;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signup.Email
{
    public class EmailQuery(IQueryRepository repository) : BaseRepository<EmailModel>(repository, ApiEndpoint.Auth.Signup.Email), IEmailQuery
    {
    }
}
