using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI.Services
{
    public class DataService : IDataService
    {
        private readonly IJsonSerializerService _jsonSerializerService;

        public DataService(IJsonSerializerService jsonSerializerService)
        {
            _jsonSerializerService = jsonSerializerService;
        }

        public async Task SaveAsync<T>(string filePath, T data) where T : class
        {
            var json = _jsonSerializerService.Serialize(data);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
