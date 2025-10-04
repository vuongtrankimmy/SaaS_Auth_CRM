using QueryService.Features.Pages.v1.Auth;

namespace QueryService.Wrapper
{
    public interface IQueryWrapper
    {
        IAuthQuery AuthQuery { get; }
    }
}
