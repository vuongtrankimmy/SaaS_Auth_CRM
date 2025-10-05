using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Theme
{
    public class ThemeQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IThemeQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Theme;
    }
}
