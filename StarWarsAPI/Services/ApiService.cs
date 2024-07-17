using System.Text.Json;
using StarWarsAPI.Exceptions;

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
            try
            {
                if (string.IsNullOrEmpty(endpoint))
                {
                    throw new HttpApiServiceException($"{endpoint}");
                }

                var response = await _httpClient.GetAsync(endpoint);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return _JsonSerializerService.Deserialize<T>(json);
            }
            catch (HttpApiServiceException ex)
            {
                throw new ArgumentException($"Endpoint was null: {ex.Message}");
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"Endpoint :{endpoint} has the following error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }

}
