using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Auth.Signin.Verify_Otp
{
    public class Verify_OtpQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IVerify_OtpQuery
    {
        private static readonly string endpoint = ApiEndpoint.Auth.Signin.VerifyOtp;
    }
}
