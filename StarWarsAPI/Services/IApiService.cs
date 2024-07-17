using StarWarsAPI.Model;

namespace StarWarsAPI.Services
{
    public interface IApiService
    {
        Task<T> GetAsync<T>(string endpoint) where T : class;
    }
}