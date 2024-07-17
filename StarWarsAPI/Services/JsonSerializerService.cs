using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarWarsAPI.Services
{
    public class JsonSerializerService : IJsonSerializerService
    {
        private readonly JsonSerializerOptions _serializerOptions;

        public JsonSerializerService()
        {
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public T Deserialize<T>(string json) where T : class
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json, _serializerOptions);
            }
            catch (JsonException ex)
            {
                throw new ArgumentException($"Failed to deserialize Json: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error to deserializing Json: {ex.Message}");
            }
        }

        public string Serialize<T>(T data) where T : class
        {
            return JsonSerializer.Serialize<T>(data, _serializerOptions);
        }
    }
}
