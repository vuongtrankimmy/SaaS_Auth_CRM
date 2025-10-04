using Repositories.Repository;

namespace Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        private readonly IQueryRepository _repository;
        private readonly string _endpoint;
        public BaseRepository(IQueryRepository repository, string endpoint) => (_repository, _endpoint) = (repository, endpoint);
        public async Task<T> GetAsync<T>(int pageIndex = 1) => await _repository.GetAsync<T>(_endpoint + (pageIndex > 0 ? "?pageIndex=" + pageIndex : ""));
        public async Task<T> PostAsync<T>(object data, int pageIndex = 1) => await _repository.PostAsync<T>(data, _endpoint + (pageIndex > 0 ? "?pageIndex=" + pageIndex : ""));
        public async Task<T> PutAsync<T>(object data, string _id = "") => await _repository.PutAsync<T>(data, _endpoint + (!string.IsNullOrEmpty(_id) ? "?_id=" + _id : ""));
        public async Task<T> DeleteAsync<T>(string _id) => await _repository.DeleteAsync<T>(_endpoint + "?_id=" + _id);
    }
}
