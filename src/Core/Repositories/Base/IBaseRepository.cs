namespace Repositories.Base
{
    public interface IBaseRepository<TEntity>
    {
        Task<T> GetAsync<T>(int pageIndex = 1);
        Task<T> PostAsync<T>(object data, int pageIndex = 1);
        Task<T> PutAsync<T>(object data, string _id = "");
        Task<T> DeleteAsync<T>(string _id);
    }
}
