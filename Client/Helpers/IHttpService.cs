using System.Threading.Tasks;

namespace Datacar.Client.Helpers
{
    public interface IHttpService
    {
        Task<HTTPResponseWrapper<T>> Get<T>(string url);
        Task<HTTPResponseWrapper<object>> Post<T>(string url, T data);
    }
}
