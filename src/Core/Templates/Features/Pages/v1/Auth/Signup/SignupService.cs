using QueryService.Wrapper;
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
    public class SignupService(IQueryWrapper queryWrapper) : ISignupService
    {
        public IBasic_InformationService Basic_InformationService => basic_InformationService ??= new Basic_InformationService(queryWrapper);
        IBasic_InformationService? basic_InformationService;

        public IBirthOfDayService BirthOfDayService => birthOfDayService ??= new BirthOfDayService(queryWrapper);
        IBirthOfDayService? birthOfDayService;

        public IEmailService EmailService => emailService ??= new EmailService(queryWrapper);
        IEmailService? emailService;

        public INew_PasswordService New_PasswordService => new_PasswordService ??= new New_PasswordService(queryWrapper);
        INew_PasswordService? new_PasswordService;

        public IPhoneService PhoneService => phoneService ??= new PhoneService(queryWrapper);
        IPhoneService? phoneService;

        public IVerifyService VerifyService => verifyService ??= new VerifyService(queryWrapper);
        IVerifyService? verifyService;

        public IVerify_OtpService Verify_OtpService => verify_OtpService ??= new Verify_OtpService(queryWrapper);
        IVerify_OtpService? verify_OtpService;

        public IYour_NameService Your_NameService => your_NameService ??= new Your_NameService(queryWrapper);
        IYour_NameService? your_NameService;
    }
}
