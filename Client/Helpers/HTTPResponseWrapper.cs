using System.Net.Http;
using System.Threading.Tasks;

namespace Datacar.Client.Helpers
{
    public class HTTPResponseWrapper<T>
    {
        public HTTPResponseWrapper(T response, bool success, HttpResponseMessage httpResponseMessage)
        {
            Success = success;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }
        public bool Success { get; set; }
        public T Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get;set;}
        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }


}
