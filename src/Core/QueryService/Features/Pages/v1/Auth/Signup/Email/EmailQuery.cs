using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Auth.Signup.Email
{
    public class EmailQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IEmailQuery
    {
        private static readonly string endpoint = ApiEndpoint.Auth.Signup.Email;
    }
}
