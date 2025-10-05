using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Auth.Signup.Phone
{
    public class PhoneQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IPhoneQuery
    {
        private static readonly string endpoint = ApiEndpoint.Auth.Signup.Phone;
    }
}
