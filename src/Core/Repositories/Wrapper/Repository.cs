using Helpers.Helper.Convert;
using Microsoft.Extensions.Configuration;
using Repositories.Repository;

namespace Repositories.Wrapper
{
    public class Repository(IConfiguration config, JsonService jsonService) : IRepository
    {
        public IQueryRepository QueryRepository => field ??= new QueryRepository(config, jsonService);
    }
}
