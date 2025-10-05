using QueryService.Wrapper;
using Templates.Features.Pages.v1.Auth.Account_Choose;
using Templates.Features.Pages.v1.Auth.Signin;
using Templates.Features.Pages.v1.Auth.Signup;

namespace Templates.Features.Pages.v1.Auth
{
    public class AuthService(IQueryWrapper queryWrapper) : IAuthService
    {
        public IAccount_ChooseService Account_ChooseService => account_ChooseService ??= new Account_ChooseService(queryWrapper);
        IAccount_ChooseService? account_ChooseService;
        public ISigninService SigninService => signinService ??= new SigninService(queryWrapper);
        ISigninService? signinService;
        public ISignupService SignupService => signupService ??= new SignupService(queryWrapper);
        ISignupService? signupService;
    }
}
