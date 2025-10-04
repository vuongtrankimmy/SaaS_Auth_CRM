using QueryService.Features.Pages.v1.Auth.Signin;
using QueryService.Features.Pages.v1.Auth.Signup;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth
{
    public class AuthQuery(IQueryRepository? _queryRepository) : IAuthQuery
    {
        public ISigninQuery SigninQuery => signinQuery ??= new SigninQuery(_queryRepository);
        ISigninQuery? signinQuery;
        public ISignupQuery SignupQuery => signupQuery ??= new SignupQuery(_queryRepository);
        ISignupQuery? signupQuery;
    }
}
