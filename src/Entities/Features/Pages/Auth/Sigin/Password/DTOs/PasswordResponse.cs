namespace Entities.Features.Pages.Auth.Sigin.Password.DTOs
{
    public class PasswordResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string expires { get; set; }
        public int account_typeID { get; set; }
    }
}
