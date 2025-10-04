using QueryService.Features.Pages.Auth.Account_Choose;
using QueryService.Features.Pages.v1.Auth.Account_Choose;
using QueryService.Features.Pages.v1.Auth.Signin.Account;
using QueryService.Features.Pages.v1.Auth.Signin.Password;
using QueryService.Features.Pages.v1.Auth.Signin.Reset_Password;
using QueryService.Features.Pages.v1.Auth.Signin.Verify_Otp;
using QueryService.Features.Pages.v1.Auth.Signin.Verify_Type;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Signin
{
    public class SigninQuery(IQueryRepository? _queryRepository) : ISigninQuery
    {
        public IAccount_ChooseQuery Account_ChooseQuery => account_ChooseQuery ??= new Account_ChooseQuery(_queryRepository);
        IAccount_ChooseQuery? account_ChooseQuery;

        #region Signin
        public IAccountQuery AccountQuery => accountQuery ??= new AccountQuery(_queryRepository);
        IAccountQuery? accountQuery;

        public IPasswordQuery PasswordQuery => passwordQuery ??= new PasswordQuery(_queryRepository);
        IPasswordQuery? passwordQuery;

        public IReset_PasswordQuery Reset_PasswordQuery => reset_PasswordQuery ??= new Reset_PasswordQuery(_queryRepository);
        IReset_PasswordQuery? reset_PasswordQuery;

        public IVerify_OtpQuery Verify_OtpQuery => verify_OtpQuery ??= new Verify_OtpQuery(_queryRepository);
        IVerify_OtpQuery? verify_OtpQuery;

        public IVerify_TypeQuery Verify_TypeQuery => verify_TypeQuery ??= new Verify_TypeQuery(_queryRepository);
        IVerify_TypeQuery? verify_TypeQuery;
        #endregion
    }
}
