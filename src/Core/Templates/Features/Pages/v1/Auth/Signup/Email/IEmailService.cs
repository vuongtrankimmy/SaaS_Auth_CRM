namespace Templates.Features.Pages.v1.Auth.Signup.Email
{
    public interface IEmailService
    {
        Task<string> GetAsync();
    }
}
