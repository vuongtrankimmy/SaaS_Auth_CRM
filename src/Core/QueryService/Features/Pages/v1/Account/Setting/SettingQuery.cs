using Entities.Common.Endpoint;
using Entities.Features.Pages.Account.Setting;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Account.Setting
{
    public class SettingQuery(IQueryRepository repository) : BaseRepository<SettingModel>(repository, ApiEndpoint.Account.Setting), ISettingQuery
    {
    }
}
