using Newtonsoft.Json;

namespace Infrastructures.Middleware.JsonService
{
    public class JsonServiceMiddleware
    {
        public async Task<T> DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<string> SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
