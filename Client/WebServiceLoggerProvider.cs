using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace Datacar.Client
{
    public class WebServiceLoggerProvider : ILoggerProvider
    {
        public readonly HttpClient Client;
        public WebServiceLoggerProvider(HttpClient _client)
        {
            this.Client = _client;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new WebServiceLogger(this);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
