using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI.Services
{
    public interface IDataService
    {
        Task SaveAsync<T>(string filePath, T data) where T : class;
    }
}
