using System.Text.Json;

namespace StarWarsAPI.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IJsonSerializerService _JsonSerializerService;

        public ApiService(HttpClient httpclient, IJsonSerializerService jsonSerializerService)
        {
            _httpClient = httpclient;
            _JsonSerializerService = jsonSerializerService;
        }

        public async Task<T> GetAsync<T>(string endpoint) where T : class
        {
            var response = await _httpClient.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return _JsonSerializerService.Deserialize<T>(json);
        }
    }

}
