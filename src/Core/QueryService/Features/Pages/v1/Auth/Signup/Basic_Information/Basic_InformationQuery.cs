using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Auth.Signup.Basic_Information
{
    public class Basic_InformationQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IBasic_InformationQuery
    {
        private static readonly string endpoint = ApiEndpoint.Auth.Signup.BasicInformation;
    }
}
