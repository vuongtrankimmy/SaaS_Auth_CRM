namespace Shared.Data.Html
{
    public static class HtmlPathFactory
    {
        private static HtmlConfig configV1 = new() { Channel = HtmlChannel.Mobile, Version = "v1" };
        public class Auth
        {
            public static string AccountChoose = HtmlPath.Get(configV1, HtmlModule.Auth, "Account_Choose");
            public class Signin
            {
                private static string baseSignin = "Signin/";
                public static string Account = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignin + "Account");
                public static string New_Password = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignin + "New_Password");
                public static string Password = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignin + "Password");
                public static string Reset_Password = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignin + "Reset_Password");
                public static string Verify_Otp = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignin + "Verify_Otp");
                public static string Verify_Type = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignin + "Verify_Type");
            }
            public class Signup
            {
                private static string baseSignup = "Signup/";
                public static string Basic_Information = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignup + "Basic_Information");
                public static string BirthOfDay = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignup + "BirthOfDay");
                public static string Email = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignup + "Email");
                public static string New_Password = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignup + "New_Password");
                public static string Phone = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignup + "Phone");
                public static string Verify = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignup + "Verify");
                public static string Verify_Otp = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignup + "Verify_Otp");                
                public static string Your_Name = HtmlPath.Get(configV1, HtmlModule.Auth, baseSignup + "Your_Name");
            }
        }
        public class Account
        {
            public static string Application = HtmlPath.Get(configV1, HtmlModule.Account, "Application");
            public static string Security = HtmlPath.Get(configV1, HtmlModule.Account, "Security");
            public static string Setting = HtmlPath.Get(configV1, HtmlModule.Account, "Setting");
            public static string Workspace = HtmlPath.Get(configV1, HtmlModule.Account, "Workspace");
        }

        public class Billing
        {
            public static string Address = HtmlPath.Get(configV1, HtmlModule.Account, "Address");
            public static string Invoice = HtmlPath.Get(configV1, HtmlModule.Account, "Invoice");
            public static string Payment = HtmlPath.Get(configV1, HtmlModule.Account, "Payment");
            public static string Service = HtmlPath.Get(configV1, HtmlModule.Account, "Service");
        }
    }
}
