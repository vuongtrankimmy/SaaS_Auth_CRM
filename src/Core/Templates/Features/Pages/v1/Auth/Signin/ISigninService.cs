using Templates.Features.Pages.v1.Auth.Signin.Account;
using Templates.Features.Pages.v1.Auth.Signin.New_Password;
using Templates.Features.Pages.v1.Auth.Signin.Password;
using Templates.Features.Pages.v1.Auth.Signin.Reset_Password;
using Templates.Features.Pages.v1.Auth.Signin.Verify_Otp;
using Templates.Features.Pages.v1.Auth.Signin.Verify_Type;

namespace Templates.Features.Pages.v1.Auth.Signin
{
    public interface ISigninService
    {
        IAccountService AccountService {  get; }
        INew_PasswordService New_PasswordService { get; }
        IPasswordService PasswordService {  get; }
        IReset_PasswordService Reset_PasswordService { get; }
        IVerify_OtpService Verify_OtpService {  get; }
        IVerify_TypeService Verify_TypeService {  get; }
    }
}
