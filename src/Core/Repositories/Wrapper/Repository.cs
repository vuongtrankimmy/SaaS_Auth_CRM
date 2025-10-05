using Repositories.Base;
using Repositories.Repository;

namespace Repositories.Wrapper
{
    public abstract class Repository(IQueryRepository queryRepository, string _endpoint) : BaseRepository(queryRepository, _endpoint), IRepository
    {
     
    }
}
