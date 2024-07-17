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
            return JsonSerializer.Deserialize<T>(json, _serializerOptions);
        }
    }
}
