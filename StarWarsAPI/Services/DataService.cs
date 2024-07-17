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
            try
            {
                if (filePath == null)
                {
                    throw new Exception($"filepath is null: {filePath}");
                }

                var json = _jsonSerializerService.Serialize(data);

                if (json == null)
                {
                    throw new Exception($"Json is null: {json}");
                }

                await File.WriteAllTextAsync(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing file: {ex.Message}");
                throw;
            }
        }
    }
}
