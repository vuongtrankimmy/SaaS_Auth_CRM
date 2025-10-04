using QueryService.Features.Pages.v1.Auth;
using Repositories.Repository;

namespace QueryService.Wrapper
{
    public class QueryWrapper(IQueryRepository? _queryRepository) : IQueryWrapper
    {
        public IAuthQuery AuthQuery => authQuery ??= new AuthQuery(_queryRepository);
        IAuthQuery? authQuery;
    }
}
