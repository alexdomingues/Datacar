using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacar.Client.Helpers
{
    public class DisplayMessage: IDisplayMessage
    {
        private readonly IJSRuntime js;

        public DisplayMessage(IJSRuntime js)
        {
            this.js = js;
        }

        public async ValueTask DisplayErrorMessage(string message)
        {
            await DoDisplayMessage("Error", message, "error");
        }

        public async ValueTask DisplaySuccessMessage(string message)
        {
            await DoDisplayMessage("Success", message, "success");
        }

        public async ValueTask DisplayWarningMessage(string message)
        {
            await DoDisplayMessage("Warning", message, "warning");
        }

        private async ValueTask DoDisplayMessage(string title, string message, string messageType)
        {
            await js.InvokeVoidAsync("Swal.fire", title, message, messageType);
        }
    }
}
