using Templates.Features.Pages.v1.Auth.Signup.Basic_Information;
using Templates.Features.Pages.v1.Auth.Signup.BirthOfDay;
using Templates.Features.Pages.v1.Auth.Signup.Email;
using Templates.Features.Pages.v1.Auth.Signup.New_Password;
using Templates.Features.Pages.v1.Auth.Signup.Phone;
using Templates.Features.Pages.v1.Auth.Signup.Verify;
using Templates.Features.Pages.v1.Auth.Signup.Verify_Otp;
using Templates.Features.Pages.v1.Auth.Signup.Your_Name;

namespace Templates.Features.Pages.v1.Auth.Signup
{
    public interface ISignupService
    {
        IBasic_InformationService Basic_InformationService {  get; }
        IBirthOfDayService BirthOfDayService {  get; }
        IEmailService EmailService {  get; }
        INew_PasswordService New_PasswordService {  get; }
        IPhoneService PhoneService {  get; }
        IVerifyService VerifyService {  get; }
        IVerify_OtpService Verify_OtpService {  get; }
        IYour_NameService Your_NameService {  get; }
    }
}
