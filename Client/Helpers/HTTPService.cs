﻿using Microsoft.Extensions.Logging;
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
                var response = await Deserialize<T>(responseHTTP, defaultJsonSerializerOptions);
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

        public async Task<HTTPResponseWrapper<object>> Put<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, stringContent);
            return new HTTPResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HTTPResponseWrapper<object>> Delete(string url)
        {
            var responseHTTP = await httpClient.DeleteAsync(url);
            return new HTTPResponseWrapper<object>(null, responseHTTP.IsSuccessStatusCode, responseHTTP);
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {

            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, options);
        }
    }
}
