using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace Prototype
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetHandler();
    }
}
