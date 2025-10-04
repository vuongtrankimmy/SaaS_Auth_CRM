using QueryService.Features.Pages.v1.Auth.Signup.Basic_Information;
using QueryService.Features.Pages.v1.Auth.Signup.BirthOfDay;
using QueryService.Features.Pages.v1.Auth.Signup.Email;
using QueryService.Features.Pages.v1.Auth.Signup.New_Password;
using QueryService.Features.Pages.v1.Auth.Signup.Phone;
using QueryService.Features.Pages.v1.Auth.Signup.Verify;
using QueryService.Features.Pages.v1.Auth.Signup.Verify_Otp;
using QueryService.Features.Pages.v1.Auth.Signup.Your_Name;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signup
{
    public class SignupQuery(IQueryRepository? _queryRepository) : ISignupQuery
    {
        public IBasic_InformationQuery Basic_InformationQuery => basic_InformationQuery ??= new Basic_InformationQuery(_queryRepository);
        IBasic_InformationQuery? basic_InformationQuery;
        public IBirthOfDayQuery BirthOfDayQuery => birthOfDayQuery ??= new BirthOfDayQuery(_queryRepository);
        IBirthOfDayQuery? birthOfDayQuery;

        public IEmailQuery EmailQuery => emailQuery ??= new EmailQuery(_queryRepository);
        IEmailQuery? emailQuery;
        public INew_PasswordQuery New_PasswordQuery => new_PasswordQuery ??= new New_PasswordQuery(_queryRepository);
        INew_PasswordQuery? new_PasswordQuery;
        public IPhoneQuery PhoneQuery => phoneQuery ??= new PhoneQuery(_queryRepository);
        IPhoneQuery? phoneQuery;

        public IVerifyQuery VerifyQuery => verifyQuery ??= new VerifyQuery(_queryRepository);
        IVerifyQuery? verifyQuery;
        public IVerify_OtpQuery Verify_OtpQuery => verify_OtpQuery ??= new Verify_OtpQuery(_queryRepository);
        IVerify_OtpQuery? verify_OtpQuery;

        public IYour_NameQuery Your_NameQuery => your_NameQuery ??= new Your_NameQuery(_queryRepository);
        IYour_NameQuery? your_NameQuery;
    }
}
