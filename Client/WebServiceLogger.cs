using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Datacar.Client
{
    public class WebServiceLogger:ILogger
    {
        protected readonly WebServiceLoggerProvider ServiceProvider;

        public WebServiceLogger(WebServiceLoggerProvider service)
        {
            ServiceProvider = service;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string Logdata = DateTime.Now.ToString();
            string dataException = exception != null ? exception.Message : state.ToString();
            Datacar.Shared.Log log = new Datacar.Shared.Log
            {
                Data = $"{Logdata} {dataException}",
                Level = logLevel.ToString()
            };
            string dataToSend = JsonSerializer.Serialize<Datacar.Shared.Log>(log);
            StringContent content = new StringContent(dataToSend, System.Text.Encoding.UTF8, "application/json");
            Task.Run(async delegate
            {
                var response = await ServiceProvider.Client.PostAsync("api/log/save", content);
                var IsOk = response.IsSuccessStatusCode;
                /*Console.WriteLine(IsOk + " MY LOG INIT");*/
             });
        }
    }
}
