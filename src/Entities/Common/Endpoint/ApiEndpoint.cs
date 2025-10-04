namespace Entities.Common.Endpoint
{
    public static class ApiEndpoint
    {
        private const string Api = "/api";
        private const string Version = "/v1";
        private static readonly string BaseUrl = $"{Api}{Version}";

        public static class Auth
        {
            private static readonly string AuthBase = $"{BaseUrl}/auth";
            public static readonly string AccountChoose = $"{AuthBase}/account_choose";
            public static readonly string NewPassword = $"{AuthBase}/new_password";
            public class Signin
            {
                public static readonly string Account = $"{AuthBase}/account";
                
                public static readonly string Password = $"{AuthBase}/password";
                public static readonly string ResetPassword = $"{AuthBase}/reset_password";
                public static readonly string VerifyOtp = $"{AuthBase}/verify_otp";
                public static readonly string VerifyType = $"{AuthBase}/verify_type";
            }
            
            public class Signup
            {
                public static readonly string BasicInformation = $"{AuthBase}/basic_information";
                public static readonly string BirthOfDay = $"{AuthBase}/birth_of_day";
                public static readonly string Email = $"{AuthBase}/email";
                public static readonly string Phone = $"{AuthBase}/phone";
                public static readonly string Verify = $"{AuthBase}/verify";
                public static readonly string VerifyOtp = $"{AuthBase}/verify_otp";
                public static readonly string YourName = $"{AuthBase}/your_name";
            }
        }
       

        public static class Hr
        {
            private static readonly string HrBase = $"{BaseUrl}/hr";
            public static readonly string Account = $"{HrBase}/account";
            public static readonly string Attendance = $"{HrBase}/attendance";
            public static readonly string Bonus = $"{HrBase}/bonus";
            public static readonly string Component = $"{HrBase}/component";
            public static readonly string Department = $"{HrBase}/department";
            public static readonly string DesignToken = $"{HrBase}/designToken";
            public static readonly string Employee = $"{HrBase}/employee";
            public static readonly string Insurance = $"{HrBase}/insurance";
            public static readonly string Kpi = $"{HrBase}/kpi";
            public static readonly string Leave = $"{HrBase}/leave";
            public static readonly string Payroll = $"{HrBase}/payroll";
            public static readonly string Penalty = $"{HrBase}/penalty";
            public static readonly string Performance = $"{HrBase}/performance";
            public static readonly string Position = $"{HrBase}/position";
            public static readonly string Promotion = $"{HrBase}/promotion";
            public static readonly string Role = $"{HrBase}/role";
            public static readonly string Salary = $"{HrBase}/salary";
            public static readonly string Tax = $"{HrBase}/tax";
            public static readonly string Tenant = $"{HrBase}/tenant";
            public static readonly string Theme = $"{HrBase}/theme";
            public static readonly string Training = $"{HrBase}/training";
        }
    }
}
