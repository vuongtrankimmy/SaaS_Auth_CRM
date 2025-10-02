namespace Entities.Features.Auth.Signin.DTOs
{
    public class SigninResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string expires { get; set; }
        public int account_typeID { get; set; }
    }
}
