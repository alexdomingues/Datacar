using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Datacar.Client.Helpers
{
    public class HTTPService: IHttpService
    {
        private readonly HttpClient httpClient;
        public HTTPService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HTTPResponseWrapper<object>> Post<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, stringContent);
            return new HTTPResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }
    }
}
