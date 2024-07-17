using StarWarsAPI.Model;

namespace StarWarsAPI.Services
{
    public interface IApiService
    {
        Task<string> GetAsync<T>(string endpoint) where T : class;
    }
}