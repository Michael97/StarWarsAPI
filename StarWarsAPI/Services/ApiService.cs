using System;
using System.Text.Json;
using NLog;
using StarWarsAPI.Exceptions;

namespace StarWarsAPI.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IJsonSerializerService _JsonSerializerService;
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

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

                _logger.Info($"Fetching data from {endpoint}");

                var response = await _httpClient.GetAsync(endpoint);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return _JsonSerializerService.Deserialize<T>(json);
            }
            catch (HttpApiServiceException ex)
            {
                var response = $"Endpoint was null: {ex.Message}";
                _logger.Info(response);
                throw new ArgumentException(response);
            }
            catch (HttpRequestException ex)
            {
                var response = $"Endpoint :{endpoint} has the following error: {ex.Message}";
                _logger.Info(response);
                throw new ArgumentException(response);
            }
            catch (Exception ex)
            {
                _logger.Info(ex.Message);
                throw new ArgumentException(ex.Message);
            }
        }
    }

}
