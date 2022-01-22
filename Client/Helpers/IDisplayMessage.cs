using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacar.Client.Helpers
{
    interface IDisplayMessage
    {
        ValueTask DisplayErrorMessage(string message);
        ValueTask DisplaySuccessMessage(string message);
        ValueTask DisplayWarningMessage(string message);
        Task SweetAlert(string type, string message);
    }
}
