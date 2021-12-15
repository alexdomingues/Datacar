using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Datacar.Client.Helpers
{
    public class HTTPService: IHttpService
    {
        private readonly HttpClient httpClient;

        private JsonSerializerOptions defaultJsonSerializerOptions =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        public HTTPService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HTTPResponseWrapper<T>> Get<T>(string url)
        {
            var responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<T>(await responseHTTP.Content.ReadAsStringAsync(), defaultJsonSerializerOptions);
                return new HTTPResponseWrapper<T>(response, true, responseHTTP);
            }
            else
            {
                return new HTTPResponseWrapper<T>(default, false, responseHTTP);
            }
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
