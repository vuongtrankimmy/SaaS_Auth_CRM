using Repositories.Repository;

namespace Repositories.Base
{
    public abstract class BaseRepository(IQueryRepository queryRepository, string _endpoint) : IBaseRepository
    {
        public async Task<T> GetAsync<T>(int pageIndex = 1) => await queryRepository.GetAsync<T>(_endpoint + (pageIndex > 0 ? "?pageIndex=" + pageIndex : ""));
        public async Task<T> PostAsync<T>(object data, int pageIndex = 1) => await queryRepository.PostAsync<T>(data, _endpoint + (pageIndex > 0 ? "?pageIndex=" + pageIndex : ""));
        public async Task<T> PutAsync<T>(object data, string _id = "") => await queryRepository.PutAsync<T>(data, _endpoint + (!string.IsNullOrEmpty(_id) ? "?_id=" + _id : ""));
        public async Task<T> DeleteAsync<T>(string _id) => await queryRepository.DeleteAsync<T>(_endpoint + "?_id=" + _id);
    }
}
