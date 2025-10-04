using QueryService.Features.Pages.Auth.Account_Choose;
using QueryService.Features.Pages.v1.Auth.Signin.Account;
using QueryService.Features.Pages.v1.Auth.Signin.Password;
using QueryService.Features.Pages.v1.Auth.Signin.Reset_Password;
using QueryService.Features.Pages.v1.Auth.Signin.Verify_Otp;
using QueryService.Features.Pages.v1.Auth.Signin.Verify_Type;

namespace QueryService.Features.Pages.v1.Auth.Signin
{
    public interface ISigninQuery
    {
        IAccount_ChooseQuery Account_ChooseQuery { get; }
        IAccountQuery AccountQuery {  get; }
        IPasswordQuery PasswordQuery {  get; }
        IReset_PasswordQuery Reset_PasswordQuery {  get; }
        IVerify_OtpQuery Verify_OtpQuery {  get; }
        IVerify_TypeQuery Verify_TypeQuery {  get; }
    }
}
