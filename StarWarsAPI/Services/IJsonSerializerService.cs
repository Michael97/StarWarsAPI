using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarWarsAPI.Services
{
    public interface IJsonSerializerService
    {
        public T Deserialize<T>(string json) where T : class;
        public string Serialize<T>(T json) where T : class;
    }
}
