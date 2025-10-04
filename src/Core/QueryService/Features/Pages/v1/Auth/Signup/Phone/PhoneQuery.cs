using Entities.Common.Endpoint;
using Entities.Features.Pages.Auth.Signup.Phone;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signup.Phone
{
    public class PhoneQuery(IQueryRepository repository) : BaseRepository<PhoneModel>(repository, ApiEndpoint.Auth.Signup.Phone), IPhoneQuery
    {
    }
}
