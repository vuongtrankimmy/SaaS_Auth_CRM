using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Theme;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Theme
{
    public class ThemeQuery(IQueryRepository repository) : BaseRepository<ThemeModel>(repository, ApiEndpoint.Hr.Theme), IThemeQuery
    {
    }
}
