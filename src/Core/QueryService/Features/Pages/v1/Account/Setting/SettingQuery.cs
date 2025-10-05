using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Account.Setting
{
    public class SettingQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), ISettingQuery
    {
        private static readonly string endpoint = ApiEndpoint.Account.Setting;
    }
}
