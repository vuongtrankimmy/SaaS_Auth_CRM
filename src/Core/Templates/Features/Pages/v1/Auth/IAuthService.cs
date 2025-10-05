using Templates.Features.Pages.v1.Auth.Account_Choose;
using Templates.Features.Pages.v1.Auth.Signin;
using Templates.Features.Pages.v1.Auth.Signup;

namespace Templates.Features.Pages.v1.Auth
{
    public interface IAuthService
    {
        IAccount_ChooseService Account_ChooseService { get; }
        ISigninService SigninService { get; }
        ISignupService SignupService { get; }
    }
}
