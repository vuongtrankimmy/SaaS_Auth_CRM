using Repositories.Base;
using Repositories.Repository;

namespace Repositories.Wrapper
{
    public interface IRepository
    {
        IQueryRepository QueryRepository {  get; }
    }
}
