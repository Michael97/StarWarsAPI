using StarWarsAPI.Model;

namespace StarWarsAPI.Services
{
    public interface IApiService
    {
        Task<FilmsResponse> GetAsync<FilmsResponse>(string endpoint);
    }
}