namespace Repositories.Repository
{
    public interface IQueryRepository
    {
        Task<T> GetAsync<T>(string endpoint);
        Task<T> PostAsync<T>(object data, string endpoint);
        Task<T> PutAsync<T>(object data, string endpoint);
        Task<T> DeleteAsync<T>(string endpoint);
    }
}
