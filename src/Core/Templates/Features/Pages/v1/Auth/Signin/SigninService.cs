using QueryService.Wrapper;
using Templates.Features.Pages.v1.Auth.Signin.Account;
using Templates.Features.Pages.v1.Auth.Signin.New_Password;
using Templates.Features.Pages.v1.Auth.Signin.Password;
using Templates.Features.Pages.v1.Auth.Signin.Reset_Password;
using Templates.Features.Pages.v1.Auth.Signin.Verify_Otp;
using Templates.Features.Pages.v1.Auth.Signin.Verify_Type;

namespace Templates.Features.Pages.v1.Auth.Signin
{
    public class SigninService(IQueryWrapper queryWrapper) : ISigninService
    {
        public IAccountService AccountService => accountService ??= new AccountService(queryWrapper);
        IAccountService? accountService;
        public INew_PasswordService New_PasswordService => new_PasswordService ??= new New_PasswordService(queryWrapper);
        INew_PasswordService? new_PasswordService;
        public IPasswordService PasswordService => passwordService ??= new PasswordService(queryWrapper);
        IPasswordService? passwordService;
        public IReset_PasswordService Reset_PasswordService => reset_PasswordService ??= new Reset_PasswordService(queryWrapper);
        IReset_PasswordService? reset_PasswordService;
        public IVerify_OtpService Verify_OtpService => verify_OtpService ??= new Verify_OtpService(queryWrapper);
        IVerify_OtpService? verify_OtpService;
        public IVerify_TypeService Verify_TypeService => verify_TypeService ??= new Verify_TypeService(queryWrapper);
        IVerify_TypeService? verify_TypeService;
    }
}
