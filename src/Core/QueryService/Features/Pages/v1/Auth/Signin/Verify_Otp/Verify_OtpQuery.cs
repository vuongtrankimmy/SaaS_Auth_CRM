using Entities.Common.Endpoint;
using Entities.Features.Pages.Auth.Sigin.Verify_Otp;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signin.Verify_Otp
{
    public class Verify_OtpQuery(IQueryRepository repository) : BaseRepository<Verify_OtpModel>(repository, ApiEndpoint.Auth.Signin.VerifyOtp), IVerify_OtpQuery
    {
    }
}
