using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Auth.Signup.Your_Name
{
    public class Your_NameQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IYour_NameQuery
    {
        private static readonly string endpoint = ApiEndpoint.Auth.Signup.YourName;
    }
}
