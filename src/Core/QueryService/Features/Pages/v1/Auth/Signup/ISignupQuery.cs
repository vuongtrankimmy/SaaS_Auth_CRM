using QueryService.Features.Pages.v1.Auth.Signup.Basic_Information;
using QueryService.Features.Pages.v1.Auth.Signup.BirthOfDay;
using QueryService.Features.Pages.v1.Auth.Signup.Email;
using QueryService.Features.Pages.v1.Auth.Signup.New_Password;
using QueryService.Features.Pages.v1.Auth.Signup.Phone;
using QueryService.Features.Pages.v1.Auth.Signup.Verify;
using QueryService.Features.Pages.v1.Auth.Signup.Verify_Otp;
using QueryService.Features.Pages.v1.Auth.Signup.Your_Name;

namespace QueryService.Features.Pages.v1.Auth.Signup
{
    public interface ISignupQuery
    {
        IBasic_InformationQuery Basic_InformationQuery {  get; }
        IBirthOfDayQuery BirthOfDayQuery {  get; }
        IEmailQuery EmailQuery {  get; }
        INew_PasswordQuery New_PasswordQuery {  get; }
        IPhoneQuery PhoneQuery {  get; }
        IVerifyQuery VerifyQuery {  get; }
        IVerify_OtpQuery Verify_OtpQuery {  get; }
        IYour_NameQuery Your_NameQuery {  get; }
    }
}
