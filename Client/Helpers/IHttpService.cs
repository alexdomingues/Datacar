using System.Threading.Tasks;

namespace Datacar.Client.Helpers
{
    public interface IHttpService
    {
        Task<HTTPResponseWrapper<object>> Post<T>(string url, T data);
    }
}
