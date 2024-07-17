using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI.Exceptions
{
    public class HttpApiServiceException : Exception
    {
        public HttpApiServiceException(string message) : base (message)
        {
        
        }
    }
}
