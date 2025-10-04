using QueryService.Features.Pages.v1.Auth.Signin;
using QueryService.Features.Pages.v1.Auth.Signup;

namespace QueryService.Features.Pages.v1.Auth
{
    public interface IAuthQuery
    {
        ISigninQuery SigninQuery {  get; }
        ISignupQuery SignupQuery {  get; }
    }
}
